using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools {
    public class CameraController2D : MonoBehaviour {
        [SerializeField] protected float LerpSpeed = 0.1f;

        [SerializeField] protected Transform Target;
        [SerializeField] protected Vector2 TargetPosition;

        [SerializeField] protected bool StartWithTargetPosition = false;

        protected static CameraFollowPosition CFS_Position = new CameraFollowPosition();
        protected static CameraFollowTransform CFS_Transform = new CameraFollowTransform();
        protected CameraFollowStrategy CFS;
        protected Vector2 offset;

        protected float DefaultZoom;
        protected float ZoomAmount;

        [SerializeField] float ZoomSpeed = 0.1f;

        protected virtual void Awake()
        {
            if (StartWithTargetPosition)
            {
                CFS = CFS_Position;
            }
            else
            {
                CFS = CFS_Transform;
            }
            DefaultZoom = Camera.main.orthographicSize;
            ZoomAmount = DefaultZoom;
        }

        protected virtual void Update()
        {
            CFS.Update(this);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, ZoomAmount, ZoomSpeed * Time.deltaTime);
        }

        public virtual void SetTargetTransform(Transform Target)
        {
            this.Target = Target;
            CFS = CFS_Transform;
        }

        public virtual void SetTargetPosition(float x, float y)
        {
            SetTargetPosition(new Vector2(x, y));
        }

        public virtual void SetTargetPositionX(float x)
        {
            SetTargetPosition(new Vector2(x, TargetPosition.y));
        }

        public virtual void SetTargetPositionY(float y)
        {
            SetTargetPosition(new Vector2(TargetPosition.x,y));
        }

        public virtual void SetTargetPosition(Vector2 Position)
        {
            TargetPosition = Position;
            CFS = CFS_Position;
        }

        public virtual void StepTowards(Vector2 Position)
        {
            transform.position = (((Vector3)Vector2.Lerp(transform.position, Position, LerpSpeed)) + Vector3.forward * transform.position.z) + (Vector3)offset;
        }

        public virtual Transform GetTargetTransform()
        {
            return Target;
        }

        public virtual Vector3 GetTargetPosition()
        {
            return TargetPosition;
        }

        /// <summary>
        /// Follow Strategy Classes
        /// </summary>
        protected abstract class CameraFollowStrategy
        {
            public abstract void Update(CameraController2D Controller);
        }

        protected class CameraFollowPosition : CameraFollowStrategy
        {
            public override void Update(CameraController2D Controller)
            {
                Controller.StepTowards(Controller.GetTargetPosition());
            }
        }

        protected class CameraFollowTransform : CameraFollowStrategy
        {
            public override void Update(CameraController2D Controller)
            {
                if (Controller.Target == null)
                {
                    Controller.SetTargetPosition(Controller.transform.position);
                }
                else
                {
                    Controller.StepTowards(Controller.GetTargetTransform().position);
                }
            }
        }

        /// <summary>
        /// Shakes le camera
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="rate"></param>
        /// <param name="decay"></param>
        public void CameraShake(Vector2 direction, float rate, float decay)
        {
            StopAllCoroutines();
            StartCoroutine(CameraShakeRoutine(direction, rate, decay));
        }

        IEnumerator CameraShakeRoutine(Vector2 direction, float rate, float decay)
        {
            float[] angles = new float[(int)(360 / rate)];
            for (int i=0; i<angles.Length; i++)
            {
                angles[i] = Mathf.Sin(rate * i);
            }

            int angleInd = 0;
            float scale = 1;
            while (scale > 0)
            {
                scale -= decay;
                offset = direction * Mathf.Sin(angles[angleInd]) * scale;

                angleInd = (angleInd + 1) % angles.Length;

                yield return null;
            }
            offset = Vector2.zero;
        }

        /// <summary>
        /// Jolts the camera in a given direction -- then returns to center
        /// </summary>
        /// <param name="direction"></param>
        public void CameraPush(Vector2 direction)
        {
            transform.position += (Vector3)direction;
        }

        public void Zoom(float zoom)
        {
            ZoomAmount = zoom;
        }

        public void Unzoom()
        {
            ZoomAmount = DefaultZoom;
        }
    }

}