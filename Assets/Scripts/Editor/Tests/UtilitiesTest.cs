using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class UtilitiesTest {

	[Test]
	public void NearestValueSingleUnitOneAndAHalfHighTest(){
		float gridSize = 1.5f;
		float value = 1.4f;
		float expected = 1.5f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueSingleUnitOneAndAHalfLowTest(){
		float gridSize = 1.5f;
		float value = 0.4f;
		float expected = 0.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueMultiUnitOneAndAHalfLowTest(){
		float gridSize = 1.5f;
		float value = 1.8f;
		float expected = 1.5f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}


	[Test]
	public void NearestValueMultiUnitOneAndAHalfHighTest(){
		float gridSize = 1.5f;
		float value = 2.73f;
		float expected = 3.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueSingleUnitNegativeOneAndAHalfHighTest(){
		float gridSize = 1.5f;
		float value = -1.4f;
		float expected = -1.5f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueSingleUnitNegativeOneAndAHalfLowTest(){
		float gridSize = 1.5f;
		float value = -0.4f;
		float expected = 0.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueMultiUnitNegativeOneAndAHalfLowTest(){
		float gridSize = 1.5f;
		float value = -1.8f;
		float expected = -1.5f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueMultiUnitNegativeOneAndAHalfHighTest(){
		float gridSize = 1.5f;
		float value = -2.73f;
		float expected = -3.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}
		
	[Test]
	public void NearestValueSingleUnitTwoLowTest(){
		float gridSize = 2.0f;
		float value = 0.9f;
		float expected = 0.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueSingleUnitTwoHighTest(){
		float gridSize = 2.0f;
		float value = 1.9f;
		float expected = 2.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueMultiUnitTwoLowTest(){
		float gridSize = 2.0f;
		float value = 2.9f;
		float expected = 2.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueMultiUnitTwoHighTest(){
		float gridSize = 2.0f;
		float value = 3.9f;
		float expected = 4.0f;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueVector3OneAndAHalfLowTest(){
		float gridSize = 1.5f;
		Vector3 value = new Vector3 (0.7f, 0.3f, 0.2f);
		Vector3 expected = Vector3.zero;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueVector3OneAndAHalfHighTest(){
		float gridSize = 1.5f;
		Vector3 value = new Vector3 (0.95f, 1.3f, 1.2f);
		Vector3 expected = new Vector3(1.5f, 1.5f, 1.5f);

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueVector3NegativeOneAndAHalfLowTest(){
		float gridSize = 1.5f;
		Vector3 value = new Vector3 (-0.7f, -0.3f, -0.2f);
		Vector3 expected = Vector3.zero;

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

	[Test]
	public void NearestValueVector3NegativeOneAndAHalfHighTest(){
		float gridSize = 1.5f;
		Vector3 value = new Vector3 (-0.92f, -1.3f, -1.2f);
		Vector3 expected = new Vector3 (-1.5f, -1.5f, -1.5f);

		Assert.AreEqual(expected,Utilities.GetNearestValue(value,gridSize));
	}

}
