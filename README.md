This fork is for people experiencing "not allowed" type errors when using the program on Mac OS.
It may occur because the program does not skip disallowed directories - which are being created on Mac OS
automatically. 

Also using sudo did not fix the issues with the program.

I only tested the command-line tool, but it works on my machine.

﻿﻿![Screenshot](https://github.com/KirovAir/TwilightBoxart/raw/master/img/screenshot.png)

# Twilight Boxart

**PROJECT IN MAINTENANCE-MODE**

More info below:

> This project has been forked with the goal of porting from old unsupported .NET Core (making it not work on Linux due to outdated OpenSSL support) to currently supported .NET (both on Windows, MacOS and Linux).
>
> No features are planned aside from keeping it working and cleaning some unused code.
>
> Supported OSes are the same as supported by .NET 8.0.

A boxart downloader written in C#. Uses various sources and scan methods to determine the correct boxart.
Written for [TwilightMenu++](https://github.com/DS-Homebrew/TWiLightMenu) but can be used for other loader UI's with some config changes. 😊

## Supported rom types
 System | Matching (in order)
 --- | ---
 Nintendo - Game Boy | (sha1 / filename)
 Nintendo - Game Boy Color | (sha1 / filename)
 Nintendo - Game Boy Advance | (sha1 / filename)
 Nintendo - Nintendo DS | (titleid / sha1 / filename)
 Nintendo - Nintendo DSi | (titleid / sha1 / filename)
 Nintendo - Nintendo DSi (DSiWare) | (titleid / sha1 / filename)
 Nintendo - Nintendo Entertainment System | (sha1 / filename)
 Nintendo - Super Nintendo Entertainment System | (sha1 / filename)
 Nintendo - Family Computer Disk System | (sha1 / filename)
 Sega - Mega Drive - Genesis | (sha1 / filename)
 Sega - Master System - Mark III | (sha1 / filename)
 Sega - Game Gear | (sha1 / filename)

## Boxart sources
* [GameTDB](https://gametdb.com) using titleid matching.
* [LibRetro](https://github.com/libretro/libretro-thumbnails) using [NoIntro](https://datomatic.no-intro.org) sha1 matching or simply filename matching. [LibRetro DAT](https://github.com/libretro/libretro-database/tree/master/dat) is currently added as extra NES sha1 source.

## Download
[Here](https://github.com/MateusRodCosta/TwilightBoxart/releases).
