# [Engine Name]

**Status: Currently Under Active Development**

A custom 3D simulation engine combining the hardware-accelerated rendering pipeline of MonoGame with the desktop UI capabilities of Windows Presentation Foundation (WPF). 

This project aims to provide a hybrid architecture for building interactive simulation environments and tools, pairing a high-performance 3D viewport with rich, data-driven desktop interfaces.

## Overview

* **MonoGame & WPF Integration:** Bridges rendering capabilities with a robust desktop application framework.
* **Editor-Driven Interface:** Built to leverage WPF's layout and data-binding features for toolsets and inspectors alongside the 3D view.
* **Work In Progress:** Core systems, rendering pipelines, and UI interactions are currently being built and iteratively refined. Features and architecture are subject to change.

## Prerequisites

* **OS:** Windows 10/11
* **IDE:** Visual Studio 2026 (recommended)
* **Framework:** .NET 10.0

## Getting Started

*Note: Because this engine is in active development, build steps and dependencies may change.*

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/vannipper/zenith-wpf.git](https://github.com/vannipper/vannipper.git)
    cd zenith
    ```

2.  **Open the Solution:**
    Open `Zenith.sln` in Visual Studio.

3.  **Restore & Build:**
    Allow NuGet to restore packages, set the main WPF project as your Startup Project, and run. 
    
    Alternatively, build via the command line to check for errors:
    ```bash
    msbuild Zenith.sln -property:Configuration=Release
    ```

## Continuous Integration

This repository uses a GitHub Actions pipeline to automatically verify that the solution successfully compiles in Release mode on new pushes and pull requests.
