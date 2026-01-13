# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-01-13

### Added
- Unit tests for Driver class covering:
  - **Transform Tests:**
    - `Update_CorrectlyRotatesObjectBySteerSpeed()` - Verifies rotation by steerSpeed (0.5f) each frame
    - `Update_CorrectlyTranslatesObjectByMoveSpeed()` - Verifies translation by moveSpeed (0.01f) each frame
    - `Update_ApplesRotationAndTranslationToTransformAsExpected()` - Verifies both rotation and translation applied correctly in single Update() call
    - `Update_AccumulatesRotationOverMultipleFrames()` - Tests cumulative rotation over 5 frames
    - `Update_AccumulatesTranslationOverMultipleFrames()` - Tests cumulative translation over 5 frames
  - **Keyboard Input Detection Tests:**
    - `Update_ContainsForwardMovementDetectionLogic()` - Verifies forward movement detection code path exists
    - `Update_HasForwardMovementDetectionPath()` - Tests up arrow or 'w' key detection logic
    - `Update_HasBackwardMovementDetectionPath()` - Tests down arrow or 's' key detection logic
    - `Update_HasLeftMovementDetectionPath()` - Tests left arrow or 'a' key detection logic
    - `Update_HasRightMovementDetectionPath()` - Tests right arrow or 'd' key detection logic
  - **Initialization Tests:**
    - `Driver_InitializesWithDefaultSteerSpeedAndMoveSpeed()` - Verifies default initialization values
    - `Driver_CorrectlyInitializesSteerSpeedAndMoveSpeedFields()` - Verifies field initialization
    - `Driver_SerializeFieldsCorrectlyRetainValuesAfterSerialization()` - Verifies serialized values persist
- Test setup and teardown fixtures for proper GameObject lifecycle management
- Comprehensive test documentation with XML comments
- Notes on Play Mode testing for actual keyboard input detection (Edit Mode tests verify code structure)

### Changed
- Driver.Update() method changed from `private void` to `public void` for testability

### Details
- Created `Assets/Tests/DriverTests.cs` with NUnit test framework
- All tests use Arrange-Act-Assert pattern
- Floating-point comparisons use 0.001f tolerance for reliability
- Rotation wrapping (0-360 degrees) is properly handled in assertions
- [Test] attributes used for synchronous transform and movement detection tests
- Edit Mode tests verify Update() method executes and applies expected transforms
- Keyboard input tests document the code paths that detect forward, backward, left, and right movement
- Full Play Mode keyboard input testing available with Input System test utilities or runtime manual testing
