using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UISupport
{
    [ExecuteInEditMode]
    public class SafeAreaLayout : UIBehaviour
    {
        Rect appliedRect;
        bool processing;

        protected override void Start()
        {
            base.Start();
            UpdateLayout();
        }

        void ApplySafeArea(Rect safeArea)
        {
            processing = true;

            var rectTransform = (RectTransform)transform;

            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localScale = Vector3.one;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.pivot = new Vector2(0.5f, 0.5f);

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;

            processing = false;
        }

        void UpdateLayout()
        {
            var safeArea = SafeAreaResolver.Shared.GetSafeArea();

            if (safeArea != appliedRect)
            {
                ApplySafeArea(safeArea);
                appliedRect = safeArea;
            }
        }

        override protected void OnRectTransformDimensionsChange()
        {
            base.OnRectTransformDimensionsChange();
            if (!processing) UpdateLayout();
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = new Color32(0, 0, 255, 210);
            var rectTransform = (RectTransform)transform;
            var worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            Gizmos.DrawLine(worldCorners[0], worldCorners[1]);
            Gizmos.DrawLine(worldCorners[1], worldCorners[2]);
            Gizmos.DrawLine(worldCorners[2], worldCorners[3]);
            Gizmos.DrawLine(worldCorners[3], worldCorners[0]);
        }
#endif
    }

    public interface ISafeAreaResolver
    {
        Rect GetSafeArea();
    }

    public class SafeAreaResolver : ISafeAreaResolver
    {
        static ISafeAreaResolver sharedResolver;

        public static ISafeAreaResolver Shared
        {
            get
            {
                if (sharedResolver == null)
                {
                    sharedResolver = new SafeAreaResolver();
                }
                return sharedResolver;
            }
        }

        public Rect GetSafeArea()
        {
            return Screen.safeArea;
        }
    }
}