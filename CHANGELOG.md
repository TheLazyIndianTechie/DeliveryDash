# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.1.0] - 2026-01-13

### Added
- Unit tests for Driver class covering:
  - `Update_CorrectlyRotatesObjectBySteerSpeed()` - Verifies rotation by steerSpeed (0.5f) each frame
  - `Update_CorrectlyTranslatesObjectByMoveSpeed()` - Verifies translation by moveSpeed (0.01f) each frame
  - `Driver_InitializesWithDefaultSteerSpeedAndMoveSpeed()` - Verifies default initialization values
  - `Update_AccumulatesRotationOverMultipleFrames()` - Tests cumulative rotation over 5 frames
  - `Update_AccumulatesTranslationOverMultipleFrames()` - Tests cumulative translation over 5 frames
- Test setup and teardown fixtures for proper GameObject lifecycle management
- Comprehensive test documentation with XML comments

### Changed
- Driver.Update() method changed from `private void` to `public void` for testability

### Details
- Created `Assets/Tests/DriverTests.cs` with NUnit test framework
- All tests use Arrange-Act-Assert pattern
- Floating-point comparisons use 0.001f tolerance for reliability
- Rotation wrapping (0-360 degrees) is properly handled in assertions
