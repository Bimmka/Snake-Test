using System;
using UnityEngine;

namespace Features.Effects.Scripts.CustomParticles
{
	public class CustomParticleObserver : MonoBehaviour
	{
		[SerializeField] private ParticleSystem particleSystem;

		public event Action<CustomParticleObserver> Stopped;

		public void Show(Vector3 at)
		{
			transform.position = at;
			gameObject.SetActive(true);
			particleSystem.Play();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
		private void OnParticleSystemStopped()
		{
			Stopped?.Invoke(this);
		}
	}
}