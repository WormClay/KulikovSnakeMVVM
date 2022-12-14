using UnityEngine;
using System.Collections.Generic;
namespace Snake
{
	public sealed class PoolContainer
	{
		private readonly Stack<PoolObject> _store;
		private GameObject _prefab;
		private string _prefabPath;
		private Transform _rootPool;

		public PoolContainer(string prefabPath, string rootName, int capacityPool)
		{
			_store = new Stack<PoolObject>(capacityPool);
			_prefabPath = prefabPath;
			if (!_rootPool)
			{
				_rootPool = new GameObject(rootName).transform;
			}
			Init(capacityPool);
		}

		private bool LoadPrefab()
		{
			_prefab = Resources.Load<GameObject>(_prefabPath);
			if (_prefab == null)
			{
				Debug.LogWarning("Cant load prefab " + _prefabPath);
				return false;
			}
#if UNITY_EDITOR
			if (_prefab.GetComponent<PoolObject>() != null)
			{
				Debug.LogWarning("Delete PoolObject on prefabs");
				_prefab = null;
				UnityEditor.EditorApplication.isPaused = true;
				return false;
			}
#endif

			return true;
		}

		public PoolObject Get(Transform transform)
		{
			if (_prefab == null)
			{
				if (!LoadPrefab())
				{
					return null;
				}
			}

			PoolObject poolObject;
			if (_store.Count > 0)
			{
				poolObject = _store.Pop();
			}
			else
			{
				poolObject = Object.Instantiate(_prefab).AddComponent<PoolObject>();
				poolObject.SetPool(this);
				poolObject.transform.parent = _rootPool;
			}
			//poolObject.transform.position = transform.position;
			//poolObject.transform.rotation = transform.rotation;
			poolObject.gameObject.SetActive(true);
			return poolObject;
		}

		public void Recycle(PoolObject poolObject)
		{
			if (poolObject != null && poolObject.Pool == this)
			{
				poolObject.transform.position = _rootPool.position;
				poolObject.transform.rotation = _rootPool.rotation;
				poolObject.gameObject.SetActive(false);
				if (!_store.Contains(poolObject))
				{
					_store.Push(poolObject);
				}
			}
			else
			{
#if UNITY_EDITOR
				Debug.LogWarning("PoolObject dont recycle", poolObject);
#endif
			}
		}

		private void Init(int capacity)
		{
			PoolObject[] poolObjects = new PoolObject[capacity];
			for (int i = 0; i < capacity; i++)
			{
				poolObjects[i] = Get(_rootPool);
			}
			for (int i = 0; i < capacity; i++)
			{
				poolObjects[i].Recycle();
			}
		}
	}
}
