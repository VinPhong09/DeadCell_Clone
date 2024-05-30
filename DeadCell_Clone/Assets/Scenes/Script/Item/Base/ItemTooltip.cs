using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

	public class ItemTooltip : MonoBehaviour
	{
		public static ItemTooltip Instance;

		[SerializeField] Text nameText;
		[SerializeField] Text slotTypeText;
		[SerializeField] Text statsText;
		[SerializeField] GameObject inventoryGameObject;

		

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
			}
			gameObject.SetActive(false);
		}

		public void ShowTooltip(Item item)
		{
			nameText.text = item.ItemName;
			slotTypeText.text = item.GetItemType();
			statsText.text = item.GetStat();
			gameObject.SetActive(true);
		}

		public void HideTooltip()
		{
			
			gameObject.SetActive(false);
			
		}

		
	}

