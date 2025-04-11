# MusicianAsistant# MusicianAssistant 🎶

> Cross-platform mobile app for musicians, artists, and bands to organize, digitalize, and centralize their creative work.

![Platform](https://img.shields.io/badge/platform-Android%20%7C%20iOS-blue)
![Status](https://img.shields.io/badge/status-in%20development-yellow)
![MAUI](https://img.shields.io/badge/built%20with-.NET%20MAUI-purple)

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Planned Features](#planned-features)
- [Getting Started](#getting-started)

---

## Project Overview

**MusicianAssistant** is a cross-platform mobile application (Android & iOS) built with .NET MAUI, designed to help musicians, artists, and bands efficiently manage their song notes and multiple versions of their compositions. The app allows users to keep track of different arrangements and versions of songs, and will support attaching related materials such as PDFs and videos for easy access.

A key feature under development is the integration of an AI-powered image processing service. This will enable users to take a photo of handwritten sheet music or song notes, and have it automatically converted into a clean, readable digital format — saving time and simplifying the process of digital transcription.

The application connects to a .NET Web API backend, enabling bands and artists to centralize their data in the cloud for easy editing and access across multiple devices. Supabase is currently being used for authentication and will also serve as the storage solution for PDFs, videos, and other media files. For AI image processing, a dedicated microservice (planned to be developed in Python) will handle image uploads, process them in the cloud, and return a digital-friendly version of the content.

MusicianAssistant is currently in active development, with a vision to become an essential companion for musicians seeking to digitize and organize their creative work seamlessly.

---

## Features

- ✅ **Cross-platform support** (Android & iOS)
- ✅ **Manage multiple song versions**
- ✅ **Attach PDFs and video files** to song versions
- ✅ **Local and cloud data storage**
- 🚧 **AI-powered image recognition** for handwritten notes (in development)
- 🚧 **Cloud-based media storage** using Supabase
- 🚧 **Centralized backend API** for multi-device access

---

## Tech Stack

- **Frontend:** .NET MAUI
- **Backend:** .NET Web API
- **Authentication & Storage:** Supabase
- **AI Microservice (Planned):** Python (hosted on PythonAnywhere)

---

## Architecture


- **.NET MAUI** handles the UI and local data management.
- **Web API** provides centralized data access and sync capabilities.
- **Supabase** serves for authentication and media file storage.
- **Planned AI Microservice** will process images in the cloud and return clean digital formats.

---

## Planned Features

- [ ] AI-powered image recognition for sheet music and handwritten notes
- [ ] Enhanced media support (more formats and annotations)
- [ ] Offline-first mode with automatic sync
- [ ] User feedback integration for new features
- [ ] Public & private sharing of song libraries

---

## Getting Started

> _This section will be updated as development progresses._

For now, clone the repository and stay tuned for installation instructions!

```bash
git clone https://github.com/the-nett/MusicianAsistant
