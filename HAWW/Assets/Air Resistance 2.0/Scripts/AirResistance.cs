using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 414
namespace AirResistance2
{
	[RequireComponent(typeof(Rigidbody))]
	public class AirResistance : MonoBehaviour
	{
		// Public fields for air density and variation that can be set from other scripts
		public float AirDensity { get; set; }
		public float DensityVariation { get; set; }

		[Tooltip("Number of rays per unit of area. Higher numbers are more accurate but slower.")]
		[SerializeField] private float raycastDensity = 5.0f; // Rays/m^2
		[SerializeField] private bool useOverrideDensity = false; // Should we use override the air density value?
		[SerializeField] private bool useOverrideVariation = false; // Should we override the density variation value?
		[SerializeField] private bool debug = false; // Are we in debug mode?
		[SerializeField] private float overrideAirDensity; // Override air density value
		[SerializeField] private float overrideDensityVariation; // Override density variation value
		private new Transform transform; // Transform cache
		private new Rigidbody rigidbody; // Rigidbody cache
		private Vector3 scale; // Lossy scale of the object. Used for updating values later.
		private float radius; // Radius of the object
		private float increment; // Increment for placing rays, i.e. 1 / raycaseDensity
		private RaycastHit[] hitBuffer; // Buffer for raycast hits
		private float rigidbodyDrag; // Store for rigidbody.drag

		private void Awake()
		{
			transform = GetComponent<Transform>();
			rigidbody = GetComponent<Rigidbody>();
			hitBuffer = new RaycastHit[16];
			rigidbodyDrag = rigidbody.drag;
			increment = 1.0f / raycastDensity;

			// Set our density and variation to the overrides. The inspector code handles setting this up
			AirDensity = overrideAirDensity;
			DensityVariation = overrideDensityVariation;
		}

		private void OnEnable()
		{
			rigidbody.drag = 0;
		}

		private void FixedUpdate()
		{
			// If the rigidbody is sleeping OR moving very slowly (i.e. close to sleeping), don't do anything.
			// Applying forces prevents the rigidbody from sleeping.
			if (rigidbody.IsSleeping() || GetMassNormalizedKE() < rigidbody.sleepThreshold) return;
			ValidateScale();

			Vector3 up = -rigidbody.velocity.normalized;
			Vector3 forward = new Vector3(up.z, up.x, up.y);
			Vector3 right = Vector3.Cross(up, forward);
			float force = CalculateAirResistanceForce();

			// For every ray point, cast a ray towards the object. If it hits, apply force at that position.
			for (float x = -radius; x < radius; x += increment)
			{
				for(float z = -radius; z < radius; z += increment)
				{
					Vector3 pos = (right * x + forward * z) + rigidbody.position - up * radius;
					Ray ray = new Ray(pos, up);
					int len = Physics.RaycastNonAlloc(ray, hitBuffer);
					RaycastHit hit = default;
					for(int i = 0; i < len; i++)
					{
						hit = hitBuffer[i];
						if(hit.transform != transform) continue;
						
						float variation = Random.Range(1.0f - DensityVariation, 1.0f + DensityVariation);
						rigidbody.AddForceAtPosition(force * variation * up, hit.point);
						break;
					}

					// If debug mode is enabled, draw some lines
					if (debug)
					{
						if(hit.transform == transform) Debug.DrawLine(pos, hit.point, Color.green);
						else Debug.DrawLine(pos, pos + up * radius, Color.red);
					}
				}
			}
		}

		private void OnDisable()
		{
			rigidbody.drag = rigidbodyDrag;
		}

		private void OnValidate()
		{
			overrideAirDensity = Mathf.Max(0, overrideAirDensity);
			overrideDensityVariation = Mathf.Clamp(overrideDensityVariation, 0, 1);
		}

		// Maybe not 100% physcially accurate, but a good approximation
		private float CalculateAirResistanceForce()
		{
			float c = AirDensity * increment * increment;
			float v2 = rigidbody.velocity.sqrMagnitude;
			return c * v2;
		}

		// This is a weird Unity thing. Rigidbodies sleep when their "mass-normalized kinetic energy"
		// is below rigidbody.sleepThreshold. This is an approximate calculation of the mass-normalized
		// KE that is used in FixedUpdate to detect if we should stop applying forces and let the
		// rigidbody sleep.
		private float GetMassNormalizedKE()
		{
			float e = 0.5f * rigidbody.mass * rigidbody.velocity.sqrMagnitude; // Linear KE
			
			// Angular KE
			Vector3 inertia = rigidbody.inertiaTensor;
			Vector3 av = rigidbody.angularVelocity;
			e += 0.5f * inertia.x * av.x * av.x;
			e += 0.5f * inertia.y * av.y * av.y;
			e += 0.5f * inertia.z * av.z * av.z;

			return e / rigidbody.mass;
		}

		// If the lossy scale changes, update our values
		private void ValidateScale()
		{
			if(scale == transform.lossyScale) return;
			scale = transform.lossyScale;
			radius = scale.magnitude / 2.0f;
		}
	}
}