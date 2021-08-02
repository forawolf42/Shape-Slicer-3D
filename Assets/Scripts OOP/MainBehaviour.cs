using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Mhmtbtn
{
    public class MainBehaviour : MonoBehaviour
    {
        public delegate void EndDelegate();
        
        ///jump and rotate with offset height
        protected IEnumerator Move(
            Transform movingTransform, 
            Vector3 startingPosition, 
            Quaternion startingRotation, 
            Transform targetPoint, 
            Quaternion targetRotation, 
            float duration, 
            float offsetHeight,
            [CanBeNull] EndDelegate endMethod)
        {
            for(float t=0f; t<duration+Time.deltaTime; t += Time.deltaTime)
            {
                float height = Mathf.Sin(Mathf.PI * t/duration) * offsetHeight * 2;
                movingTransform.position = Vector3.Lerp(startingPosition, targetPoint.position, t/duration) + Vector3.up * height;
                movingTransform.rotation = Quaternion.Slerp(startingRotation, targetRotation, t/duration);
                yield return 0;
            }
        
            //end of move
            endMethod?.Invoke();
        }
        
        ///move to target
        protected IEnumerator Move(
            Transform movingTransform, 
            Vector3 startingPosition,  
            Vector3 targetPosition, 
            float duration, 
            [CanBeNull] EndDelegate endMethod)
        {
            for(float t=0f; t<duration+Time.deltaTime; t += Time.deltaTime)
            {
                movingTransform.position = Vector3.Lerp(startingPosition, targetPosition, t/duration);
                yield return 0;
            }
        
            //end of move
            endMethod?.Invoke();
        }
        
        ///move and lookAt with lookAtAxisSettings settings
        /// if lookAtAxisSettings is (0,1,0) => lookAt is working only for Y axis 
        protected IEnumerator Move(
            Transform movingTransform, 
            Vector3 startingPosition,  
            Quaternion startingRotation, 
            Vector3 targetPosition, 
            Transform lookAtPoint,
            Vector3 lookAtAxisSettings,
            float duration, 
            [CanBeNull] EndDelegate endMethod)
        {
            for(float t=0f; t<duration+Time.deltaTime; t += Time.deltaTime)
            {
                movingTransform.position = Vector3.Lerp(startingPosition, targetPosition, t/duration);
                movingTransform.localRotation = Quaternion.Slerp(startingRotation, Quaternion.LookRotation(Vector3.Scale(lookAtPoint.position - movingTransform.position, lookAtAxisSettings)), t/duration);
                yield return 0;
            }
        
            //end of move
            endMethod?.Invoke();
        }
        
        ///move and lookAt with lookAtAxisSettings settings
        /// if lookAtAxisSettings is (0,1,0) => lookAt is working only for Y axis 
        protected IEnumerator Move(
            Transform movingTransform, 
            Vector3 startingPosition,  
            Quaternion startingRotation, 
            Transform targetPoint, 
            Transform lookAtPoint,
            Vector3 lookAtAxisSettings,
            float duration, 
            [CanBeNull] EndDelegate endMethod)
        {
            for(float t=0f; t<duration+Time.deltaTime; t += Time.deltaTime)
            {
                movingTransform.position = Vector3.Lerp(startingPosition, targetPoint.position, t/duration);
                movingTransform.localRotation = Quaternion.Slerp(startingRotation, Quaternion.LookRotation(Vector3.Scale(lookAtPoint.position - movingTransform.position, lookAtAxisSettings)), t/duration);
                yield return 0;
            }
        
            //end of move
            endMethod?.Invoke();
        }
        
    }

    public static class Utilities
    {
        //shuffle list
        private static System.Random rng = new System.Random();
        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
}

