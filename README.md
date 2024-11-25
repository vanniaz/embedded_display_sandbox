# embedded_display_sandbox
## A tool for editing and previewing screen rendering on embedded displays without recompiling and reflashing the firmware

This tool is intended to be used with the U8g2 Library for monochrome displays: https://github.com/olikraus/u8g2

It consists of a small Arduino project, and a companion Windows app, which are aimed at speeding up the process of getting a good looking display page.
When developing an embedded device with a display, you usually need to make several small adjustments: move a text by a couple of pixels, use a slightly different font etc. Then you recompile, reflash and look at the result. If you are not satisfied you repeat these steps, but this can be time consuming.

### How it works

Before uploading your real firmware to the target MCU, you upload a "sandbox" firmware that acts as a command interpreter. On the PC side you write a script containing a sequence of graphics commands, then the Windows app sends these commands to the MCU, and the firmware on the MCU translates them into U8g2 commands. If you need to adjust a value, you only have to change it inside the Edit box of the app, and click "Send" again. In a couple of seconds you see the effect on the target display, no need to recompile and upload.

The communication between the PC and the embedded interpreter uses a simple protocol, which maps each U8g2 function to a 3 character command code (e.g. the clearDisplay function is associated to the CLD command). The Windows application allows to write the script both in C++ syntax, which is then translated to protocol commands, or directly as protocol commands. The C++ syntax has the advantage that, once the result on the target display is satisfactory, the script can be directly copied into the source code of the real firmware. On the other hand, the C++ syntax is less concise and requires quite a bit of typing work; for this reason, an "assisted" mode is provided, which allows to select U8g2 commands from a dropdown list, and insert them into the script.

### Getting started

Before using the sandbox make sure that your hardware (MCU + display) is working correctly. Please refer to the U8g2 setup guide for instructions:
https://github.com/olikraus/u8g2/wiki/setup_tutorial

Once you are sure that the hardware is ok, you can compile and upload the sandbox firmware to the target MCU.
The firmware source code is in the Interpreter folder.

> [!NOTE]
> The source code was developed with the PlatformIO IDE, and the main file is named `main.cpp`. To use it with the Arduino IDE, rename the file to `interpreter.ino` (or another name that you like) and put the source files in a folder with the same name.

