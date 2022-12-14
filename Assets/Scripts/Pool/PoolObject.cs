using UnityEngine;
namespace Snake
{
	public sealed class PoolObject : MonoBehaviour
	{
		public PoolContainer Pool { get; private set; }
		public void SetPool(PoolContainer pool)
		{
			Pool = pool;
		}
		public void Recycle()
		{
			Pool?.Recycle(this);
		}
	}
}