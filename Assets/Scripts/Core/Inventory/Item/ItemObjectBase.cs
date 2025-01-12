﻿using System;
using Core.Inventory.Data;
using UnityEngine;

namespace Core.Inventory.Item
{
    public abstract class ItemObjectBase : MonoBehaviour, IDisposable, IItemObject
    {
        protected ItemData Data;
        protected Action OnTakeAction;

        // Не можем инитить в Init, так как ObjectType вызывается на этапе раньше
        public abstract ItemObjectType ObjectType { get; }

        public void Init(ItemData data, Action onTakeAction)
        {
            Data = data;
            OnTakeAction = onTakeAction;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Die()
        {
            Dispose();
            Hide();
            Destroy(gameObject);
        }

        public virtual void ToTake()
        {
            OnTakeAction?.Invoke();
            Game.Instance.InventoryManager.AddItemInInventory(Data);
        }

        public abstract void Dispose();
    }
}