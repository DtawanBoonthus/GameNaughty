//SpingManager.cs for unity-chan!
//Original Script is here:
//ricopin / SpingManager.cs
//Rocket Jump : http://rocketjump.skr.jp/unity3d/109/
//https://twitter.com/ricopin416
//Revised by N.Kobayashi 2014/06/24
//Y.Ebata

using UnityEngine;

namespace Animations
{
    public class SpringManager : MonoBehaviour
    {
        public float dynamicRatio = 1.0f;
        public float stiffnessForce;
        public AnimationCurve stiffnessCurve;
        public float dragForce;
        public AnimationCurve dragCurve;
        public SpringBone[] springBones;

        void Start()
        {
            UpdateParameters();
        }

#if UNITY_EDITOR
        void Update()
        {
            if (dynamicRatio >= 1.0f)
                dynamicRatio = 1.0f;
            else if (dynamicRatio <= 0.0f)
                dynamicRatio = 0.0f;
            UpdateParameters();
        }
#endif
        private void LateUpdate()
        {
            if (dynamicRatio != 0.0f)
            {
                for (int i = 0; i < springBones.Length; i++)
                {
                    if (dynamicRatio > springBones[i].threshold)
                    {
                        springBones[i].UpdateSpring();
                    }
                }
            }
        }

        private void UpdateParameters()
        {
            UpdateParameter("stiffnessForce", stiffnessForce, stiffnessCurve);
            UpdateParameter("dragForce", dragForce, dragCurve);
        }

        private void UpdateParameter(string fieldName, float baseValue, AnimationCurve curve)
        {
#if UNITY_EDITOR
            var start = curve.keys[0].time;
            var end = curve.keys[curve.length - 1].time;

            var prop = springBones[0].GetType().GetField(fieldName,
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            for (int i = 0; i < springBones.Length; i++)
            {
                if (!springBones[i].isUseEachBoneForceSettings)
                {
                    var scale = curve.Evaluate(start + (end - start) * i / (springBones.Length - 1));
                    prop.SetValue(springBones[i], baseValue * scale);
                }
            }
#endif
        }
    }
}