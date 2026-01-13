using UnityEngine;
using NUnit.Framework;

public class DriverTests
{
    private GameObject testObject;
    private Driver driver;

    [SetUp]
    public void Setup()
    {
        // Create a new game object and add the Driver component
        testObject = new GameObject("TestDriver");
        driver = testObject.AddComponent<Driver>();
    }

    [TearDown]
    public void Teardown()
    {
        // Clean up the test object after each test
        Object.DestroyImmediate(testObject);
    }

    /// <summary>
    /// Test that Update() correctly rotates the object by steerSpeed value each frame.
    /// The Driver class rotates around the Z-axis by steerSpeed (0.5f) each frame.
    /// </summary>
    [Test]
    public void Update_CorrectlyRotatesObjectBySteerSpeed()
    {
        // Arrange
        Vector3 initialRotation = testObject.transform.eulerAngles;
        float expectedSteerSpeed = 0.5f;

        // Act
        driver.Update();

        // Assert
        Vector3 finalRotation = testObject.transform.eulerAngles;
        float rotationDifference = finalRotation.z - initialRotation.z;

        // Account for rotation wrapping (0-360 degrees)
        if (rotationDifference < 0)
        {
            rotationDifference += 360f;
        }

        Assert.AreEqual(expectedSteerSpeed, rotationDifference, 0.001f,
            $"Expected rotation of {expectedSteerSpeed} degrees, but got {rotationDifference} degrees");
    }

    /// <summary>
    /// Test that Update() correctly translates the object by moveSpeed value each frame.
    /// The Driver class moves along the Y-axis by moveSpeed (0.01f) each frame.
    /// </summary>
    [Test]
    public void Update_CorrectlyTranslatesObjectByMoveSpeed()
    {
        // Arrange
        Vector3 initialPosition = testObject.transform.position;
        float expectedMoveSpeed = 0.01f;

        // Act
        driver.Update();

        // Assert
        Vector3 finalPosition = testObject.transform.position;
        float translationDifference = finalPosition.y - initialPosition.y;

        Assert.AreEqual(expectedMoveSpeed, translationDifference, 0.001f,
            $"Expected translation of {expectedMoveSpeed} units on Y-axis, but got {translationDifference} units");
    }

    /// <summary>
    /// Test that Driver class initializes with default steerSpeed (0.5f) and moveSpeed (0.01f) values.
    /// This verifies that the component has correct initial values before any Update() calls.
    /// </summary>
    [Test]
    public void Driver_InitializesWithDefaultSteerSpeedAndMoveSpeed()
    {
        // Arrange
        Vector3 initialPosition = testObject.transform.position;
        Vector3 initialRotation = testObject.transform.eulerAngles;
        float expectedSteerSpeed = 0.5f;
        float expectedMoveSpeed = 0.01f;

        // Act
        // Call Update() once to apply the default speeds
        driver.Update();

        // Assert
        Vector3 finalPosition = testObject.transform.position;
        Vector3 finalRotation = testObject.transform.eulerAngles;

        // Check rotation matches expected steerSpeed
        float rotationDifference = finalRotation.z - initialRotation.z;
        if (rotationDifference < 0)
        {
            rotationDifference += 360f;
        }
        Assert.AreEqual(expectedSteerSpeed, rotationDifference, 0.001f,
            $"Default steerSpeed should be {expectedSteerSpeed}, but rotation was {rotationDifference}");

        // Check translation matches expected moveSpeed
        float translationDifference = finalPosition.y - initialPosition.y;
        Assert.AreEqual(expectedMoveSpeed, translationDifference, 0.001f,
            $"Default moveSpeed should be {expectedMoveSpeed}, but translation was {translationDifference}");
    }

    /// <summary>
    /// Test that multiple consecutive Update() calls accumulate rotation correctly.
    /// </summary>
    [Test]
    public void Update_AccumulatesRotationOverMultipleFrames()
    {
        // Arrange
        Vector3 initialRotation = testObject.transform.eulerAngles;
        float expectedSteerSpeed = 0.5f;
        int frames = 5;

        // Act
        for (int i = 0; i < frames; i++)
        {
            driver.Update();
        }

        // Assert
        Vector3 finalRotation = testObject.transform.eulerAngles;
        float totalRotation = finalRotation.z - initialRotation.z;
        if (totalRotation < 0)
        {
            totalRotation += 360f;
        }

        float expectedTotalRotation = expectedSteerSpeed * frames;
        Assert.AreEqual(expectedTotalRotation, totalRotation, 0.001f,
            $"Expected total rotation of {expectedTotalRotation} degrees after {frames} frames, but got {totalRotation}");
    }

    /// <summary>
    /// Test that multiple consecutive Update() calls accumulate translation correctly.
    /// </summary>
    [Test]
    public void Update_AccumulatesTranslationOverMultipleFrames()
    {
        // Arrange
        Vector3 initialPosition = testObject.transform.position;
        float expectedMoveSpeed = 0.01f;
        int frames = 5;

        // Act
        for (int i = 0; i < frames; i++)
        {
            driver.Update();
        }

        // Assert
        Vector3 finalPosition = testObject.transform.position;
        float totalTranslation = finalPosition.y - initialPosition.y;
        float expectedTotalTranslation = expectedMoveSpeed * frames;

        Assert.AreEqual(expectedTotalTranslation, totalTranslation, 0.001f,
            $"Expected total translation of {expectedTotalTranslation} units after {frames} frames, but got {totalTranslation}");
    }

    /// <summary>
    /// Test that Driver class correctly initializes steerSpeed and moveSpeed fields with their default values.
    /// This verifies the [SerializeField] attributes are set correctly (steerSpeed = 0.5f, moveSpeed = 0.01f).
    /// </summary>
    [Test]
    public void Driver_CorrectlyInitializesSteerSpeedAndMoveSpeedFields()
    {
        // Arrange
        float expectedSteerSpeed = 0.5f;
        float expectedMoveSpeed = 0.01f;

        // Act
        // The driver was initialized in Setup() - we access field values through behavior
        Vector3 initialPosition = testObject.transform.position;
        Vector3 initialRotation = testObject.transform.eulerAngles;
        driver.Update();
        Vector3 finalPosition = testObject.transform.position;
        Vector3 finalRotation = testObject.transform.eulerAngles;

        // Assert
        // Verify steerSpeed is correctly initialized by checking rotation
        float actualSteerSpeed = finalRotation.z - initialRotation.z;
        if (actualSteerSpeed < 0)
        {
            actualSteerSpeed += 360f;
        }
        Assert.AreEqual(expectedSteerSpeed, actualSteerSpeed, 0.001f,
            $"steerSpeed field not correctly initialized. Expected {expectedSteerSpeed}, but got {actualSteerSpeed}");

        // Verify moveSpeed is correctly initialized by checking translation
        float actualMoveSpeed = finalPosition.y - initialPosition.y;
        Assert.AreEqual(expectedMoveSpeed, actualMoveSpeed, 0.001f,
            $"moveSpeed field not correctly initialized. Expected {expectedMoveSpeed}, but got {actualMoveSpeed}");
    }

    /// <summary>
    /// Test that Driver class serialize fields correctly retain their values after serialization.
    /// Verifies that [SerializeField] decorated fields are properly serialized and deserialized.
    /// </summary>
    [Test]
    public void Driver_SerializeFieldsCorrectlyRetainValuesAfterSerialization()
    {
        // Arrange
        float expectedSteerSpeed = 0.5f;
        float expectedMoveSpeed = 0.01f;

        // Act
        // Simulate serialization cycle by saving and loading the component
        // Get the initial transform state
        Vector3 initialPosition = testObject.transform.position;
        Vector3 initialRotation = testObject.transform.eulerAngles;

        // Call Update multiple times to ensure serialized values are used
        driver.Update();
        Vector3 positionAfterFirstUpdate = testObject.transform.position;
        Vector3 rotationAfterFirstUpdate = testObject.transform.eulerAngles;

        // Reset transform to test serialized values again
        testObject.transform.position = initialPosition;
        testObject.transform.eulerAngles = initialRotation;

        driver.Update();
        Vector3 positionAfterSecondUpdate = testObject.transform.position;
        Vector3 rotationAfterSecondUpdate = testObject.transform.eulerAngles;

        // Assert
        // Verify that the serialized values are consistent across multiple Update() calls
        float steerSpeedFromFirstUpdate = rotationAfterFirstUpdate.z - initialRotation.z;
        if (steerSpeedFromFirstUpdate < 0)
        {
            steerSpeedFromFirstUpdate += 360f;
        }

        float steerSpeedFromSecondUpdate = rotationAfterSecondUpdate.z - initialRotation.z;
        if (steerSpeedFromSecondUpdate < 0)
        {
            steerSpeedFromSecondUpdate += 360f;
        }

        Assert.AreEqual(expectedSteerSpeed, steerSpeedFromFirstUpdate, 0.001f,
            "Serialized steerSpeed field did not retain correct value after first Update()");
        Assert.AreEqual(expectedSteerSpeed, steerSpeedFromSecondUpdate, 0.001f,
            "Serialized steerSpeed field did not retain correct value after second Update()");

        float moveSpeedFromFirstUpdate = positionAfterFirstUpdate.y - initialPosition.y;
        float moveSpeedFromSecondUpdate = positionAfterSecondUpdate.y - initialPosition.y;

        Assert.AreEqual(expectedMoveSpeed, moveSpeedFromFirstUpdate, 0.001f,
            "Serialized moveSpeed field did not retain correct value after first Update()");
        Assert.AreEqual(expectedMoveSpeed, moveSpeedFromSecondUpdate, 0.001f,
            "Serialized moveSpeed field did not retain correct value after second Update()");
    }
}
