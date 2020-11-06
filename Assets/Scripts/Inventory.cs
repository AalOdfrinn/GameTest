using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Sprite emptyItemImage;
    public int coinsCount;

    public Text itemNameUI;
    public Image itemUIImage;
    public Text coinsCountText;
    public static Inventory instance;
    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;

    private void Awake()
    {
        if(instance != null){
            Debug.Log("Il y a plus d'une instance d'Inventory dans la scène");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        UpdateInventoryUI();
    }
    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }
    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();

    }
    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();

    }
    public void ConsumteItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        Item currentItem = content[0];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }
    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }
    public void GetNextItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count -1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemUIImage.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemUIImage.sprite = emptyItemImage;
            itemNameUI.text = "";

        }
    }
}
