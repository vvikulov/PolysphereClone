using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyG
{
    public class MyModelHandler : MonoBehaviour
    {
        #region Fields
        public Transform m_strawberry;

        private Vector3 m_prevTouch = -Vector2.one;//screen coordinates
        #endregion

        private void Start()
        {
            MeshFilter meshFilter = this.GetComponentInChildren<MeshFilter>();
            Vector3[] vertices = meshFilter.mesh.vertices;

            for(int i = 0; i < vertices.Length; i += 3)
            {
                float yOffset = Random.Range(-0.1f, 0.1f);
                vertices[i] = new Vector3(vertices[i].x, vertices[i].y + yOffset, vertices[i].z);
                vertices[i+1] = new Vector3(vertices[i+1].x, vertices[i+1].y + yOffset, vertices[i+1].z);
                vertices[i+2] = new Vector3(vertices[i+2].x, vertices[i+2].y + yOffset, vertices[i+2].z);
            }

            meshFilter.mesh.vertices = vertices;
        }

        private void Update()
        {
            bool isMouseLeftDown = Input.GetMouseButton(0);

            if(isMouseLeftDown && m_prevTouch.x < 0)//click first time
            {
                m_prevTouch = Input.mousePosition;
            }
            else if(isMouseLeftDown && m_prevTouch.x >= 0)
            {
                Vector3 delta = Input.mousePosition - m_prevTouch;
                m_prevTouch = Input.mousePosition;
                m_strawberry.Rotate(delta.y, -delta.x, 0.0f, Space.World);
            }
            else
            {
                m_prevTouch = -Vector2.one;
            }
        }
    }
}