using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using QuanVo.CharacterStat;

	public class StatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		public Text NameText;
		public Text ValueText;

		[NonSerialized]
		public CharacterStat Stat;

		private void OnValidate()
		{
			Text[] texts = GetComponentsInChildren<Text>();
			NameText = texts[0];
			ValueText = texts[1];
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			//StatTooltip.Instance.ShowTooltip(Stat, NameText.text);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			//StatTooltip.Instance.HideTooltip();
		}
	}


