# embedded_display_sandbox
## A tool for editing and previewing screen rendering on embedded displays without recompiling and reflashing the firmware

This tool is intended to be used with the U8g2 Library for monochrome displays: https://github.com/olikraus/u8g2

It has been tested with Arduino ESP32, but should work with most Arduino compatible MCUs.

It consists of a small Arduino project, and a companion Windows app, which are aimed at speeding up the process of getting a good looking display page.
When developing an embedded device with a display, you usually need to make several small adjustments: move a text by a couple of pixels, insert graphic elements, use a slightly different font etc. Then you recompile, reflash and look at the result. If you are not satisfied you repeat these steps, but this can be time consuming.

### How it works

Before uploading your real firmware to the target MCU, you upload a "sandbox" firmware that acts as a command interpreter. On the PC side you write a script containing a sequence of graphics commands, then the Windows app sends these commands to the MCU, and the firmware on the MCU translates them into U8g2 commands. If you need to adjust a value, you only have to change it inside the Edit box of the app, and click "Send" again. In a couple of seconds you see the effect on the target display, no need to recompile and upload. Once you are satisfied with the result you just have to copy the same commands to your source code.

<!--- ![app_example1](https://github.com/user-attachments/assets/8b37d63d-cb06-4424-8236-9f28ceeac0d4) --->

<p align="center">
  <a href="url"><img src="https://github.com/user-attachments/assets/8b37d63d-cb06-4424-8236-9f28ceeac0d4" align="center" width=50% height=50%></a>
</p>


The communication between the PC and the embedded interpreter uses a simple protocol, which maps each U8g2 function to a 3 character command code (e.g. the clearDisplay function is associated to the CLD command). The Windows application allows to write the script both in C++ syntax, which is then translated to protocol commands, or directly as protocol commands. The C++ syntax has the advantage that, once the result on the target display is satisfactory, the script can be directly copied into the source code of the real firmware. On the other hand, the C++ syntax is less concise and requires quite a bit of typing work; for this reason, an "assisted" mode is provided, which allows to select U8g2 commands from a dropdown list, and insert them into the script.

### Getting started

#### Preparing the sandbox firmware

Before using the sandbox make sure that your hardware (MCU + display) is working correctly. Please follow the U8g2 setup guide:

https://github.com/olikraus/u8g2/wiki/setup_tutorial

Check that the display initialisation is ok, and that you can write a sample text on it. Then, edit `main.cpp` in the [Arduino project ](/Arduino) folder and put there the same initialisation line, replacing the following:

```U8G2_SH1107_64X128_F_HW_I2C u8g2(U8G2_R1, 15, 5, 18);```

Now you have to decide which fonts you will be using in your project. U8g2 provides many fonts, you can see a preview here:

https://github.com/olikraus/u8g2/wiki/fntlistall

To enable the chosen fonts you have to uncomment their definition in `fontlist.h` (also in the [Arduino project ](/Arduino) folder).
If you are undecided about some fonts, you can include more fonts and switch them from the Windows app to check how they look, but keep in mind that **the number of fonts is limited by the flash capacity of your MCU**, so check your code size after the compilation to see if you are approaching the limit.

> [!NOTE]
> The source code was developed with [PlatformIO IDE](https://github.com/platformio), and the main file is named `main.cpp`. To use it with the original Arduino IDE, rename the file  `sandbox.ino` (or another name that you like) and put the source files in a folder with the same name.

At this point you can compile the Arduino project and upload it to the MCU, if everything is OK you should see this message on the display:

<!--- ![sandbox_waiting](https://github.com/user-attachments/assets/48af99e9-22ed-4666-8ab9-93680201d2fb) --->

<p align="center">
  <img width=40% height=40% src="https://github.com/user-attachments/assets/48af99e9-22ed-4666-8ab9-93680201d2fb">
</p>

#### Using the Windows application

A complete .NET solution, written in C#, is available in the [Windows](/Windows) folder. However, a precompiled exe file, along with all required configuration files, can be found in the [Debug](/Windows/DsplCmdSequencer/bin/Debug) folder. In most cases it should be possible to run the application by simply copying this folder on your Windows PC and launching the exe file directly.

Here are a few step-by-step instructions for getting started with the program:
- Click on the "Settings" button, and select the COM port to which the MCU is connected (you can also change the baudrate if necessary)
- Click on the "Check MCU Connection": after a few seconds you should get a confirmation message, and the "Font" dropdown, at the bottom of the window, should be populated with the names of the fonts which you enabled (uncommented) in `fontlist.h`:


![font_list](https://github.com/user-attachments/assets/123cf9f9-f60c-4f2e-83dc-703a7e755b3e)

- You can open a sample script by clicking on "Open File" and choosing `example.txt`, which is located in the same folder. The U8g2 commands should appear in the Command Editor box:

<p align="center">
  <img src="https://github.com/user-attachments/assets/9d8a6e4c-dd8f-48da-bbc1-218486cfd604">
</p>

- Click on "Send File" to automatically convert the script to protocol commands and send them to the MCU. You should almost immediately see the result on the display:

<p align="center">
  <img width=40% height=40% src="https://github.com/user-attachments/assets/4a037a26-b2d9-4cee-b77b-9d0a57e497db">
</p>

- At the same time the right box will show the communication log, where the transmitted messages are coloured in red and the received answers are coloured in blue. As you can see, the sandbox firmware confirms the execution of each command, and in some cases adds a few extra info (such as "getStrWidth=36 getAscent=9 getDescent=-2") which can be useful when you want to place other elements nearby:

<p align="center">
  <img src="https://github.com/user-attachments/assets/6015cd08-6942-4f4b-88a4-8c213162f27b">
</p>



