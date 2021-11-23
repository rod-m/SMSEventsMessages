using System;
using GameTools.MessageSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameTools.CustomEventSystems
{
    public class PointAndClick : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public string ClickEventName = "PointAndClick";
        public Color[] _colourStart;

        private void Awake()
        {
            _colourStart = InitColour();
        }

        private Color[] InitColour()
        {
            var cubeRenderers = GetComponentsInChildren<Renderer>();
            Color[] _colors = new Color[cubeRenderers.Length];
            int i = 0;
            foreach (var cubeRenderer in cubeRenderers)
            {
                _colors[i] = cubeRenderer.material.GetColor("_Color");
                i++;
            }

            return _colors;
        }

        private void ChangeColour(Color _color)
        {
            bool undo = false;
            if (_color == Color.clear)
            {
                undo = true;
            }
            var cubeRenderers = GetComponentsInChildren<Renderer>();
            int i = 0;
            foreach (var cubeRenderer in cubeRenderers)
            {
                //Call SetColor using the shader property name "_Color" and setting the color to red
                if (undo)
                {
                    _color = _colourStart[i];
                    i++;
                }
                
                cubeRenderer.material.SetColor("_Color", _color);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log($"Pointer Over {gameObject.name}");
            //Get the Renderer component from the new cube
            ChangeColour(Color.red);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log($"Pointer Exit {gameObject.name}");
            ChangeColour(Color.clear);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
          
            EventManager.Instance.TriggerEvent(ClickEventName);
        }
    }
}