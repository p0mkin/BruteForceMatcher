# BruteForceMatcher

## Objective
Create an application for password matching using a multi-threaded brute-force attack. The application generates a random password, hashes it using SHA256 with a static salt, and attempts to crack it by checking all combinations from length 1 to 6.

## Version History

* **first 3 commits: Setup core utilities and UI foundation**
  * Created `HashValidator` with SHA256 hashing and static salt.
  * Created `PasswordManager` for random password generation.
  * Designed the GUI (`Form1`) with required inputs, buttons, and bars.
  * Configured GitHub repo.

* **next 2 commits: Core brute force engine and UI wiring**
  * Implemented `BruteForceEngine` with recursive guessing algorithm.
  * Integrated multi-threading using `Parallel.ForEach` restricted to `Environment.ProcessorCount - 1` cores.
  * Added `CancellationToken` to immediately stop threads upon successful match or manual abort.
  * Wired engine results and live text updates to GUI.

* **v1.0 last commit: Final testing and code cleanup**
  * Added 100ms throttle to UI updates to prevent the application freezing.
  * Tested single-thread vs. multi-thread performance differences. (Usually around 10-20x+ time differences in results)
  * Prepared UML diagram and test report.
