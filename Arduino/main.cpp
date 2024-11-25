#include <Arduino.h>
#include <Wire.h>
#include <U8g2lib.h>
#include "ser_cmd.h"
#include "font_table.h"

#define MAX_TEXT_LEN	40
#define CMD2INT(s0,s1,s2)	(((s0) << 16) + ((s1) << 8) + (s2))

// macro to pass max length as a parameter to sscanf
#define FORMAT(S) "%" #S "[ !-~]"
#define RESOLVE(S) FORMAT(S)

/*
CHANGE THE INITIALIZATION BELOW ACCORDING TO YOUR HW CONFIGURATION
*/

U8G2_SH1107_64X128_F_HW_I2C u8g2(U8G2_R1, 15, 5, 18);

char textMessage[MAX_TEXT_LEN+1];

char Command[MAX_CMD_LEN+1];

//====================================================================================
int cmd2int(char *s)
//====================================================================================
{
	return ( (s[0] << 16) + (s[1] << 8) + s[2]);
}

//====================================================================================
void setup() {
//====================================================================================

	Serial.setRxBufferSize(128);
	Serial.begin(115200);

	u8g2.begin();
	u8g2.clearBuffer();

	// Draws initial screen, to check that the display is working

	u8g2.setDrawColor(1);
	u8g2.setFont(u8g2_font_6x13_mr);
	u8g2.drawStr(0,16,"Display SandBox");
	u8g2.drawStr(0,40,"Waiting for commands");
	u8g2.sendBuffer();
}

//====================================================================================
void loop() {
//====================================================================================

	if ( Serial.available())
	{
		int n = Serial.readBytesUntil(SER_NEWLINE[1], Command, MAX_CMD_LEN);
		Command[n] = '\0';

		if ( n >= MIN_CMD_LEN )
		{
			int x,y,a,d,h,w,e;
			switch ( cmd2int(Command))
			{
				case CMD2INT('C','L','D'):	// clearDisplay
					u8g2.clearDisplay();
					DEBUG_PORT.println("clearDisplay");
					break;
				case CMD2INT('D','S','T'):	// drawStr
					
					if (sscanf(Command+4, "%d,%d," RESOLVE(MAX_TEXT_LEN), &x, &y, textMessage) != 3)
					{
						DEBUG_PORT.println(F("DST: invalid parameters"));
						break;
					}
					u8g2.drawStr(x, y, textMessage);
					w = u8g2.getStrWidth(textMessage);
					a = u8g2.getAscent();
					d = u8g2.getDescent();
					//u8g2.sendBuffer();
					DEBUG_PORT.printf("drawStr x=%d y=%d %s" SER_NEWLINE, x, y, textMessage);
					DEBUG_PORT.printf("getStrWidth=%d getAscent=%d getDescent=%d" SER_NEWLINE, w, a, d);
					break;
				case CMD2INT('D','G','L'):	// drawGlyph
					if (sscanf(Command+4, "%d,%d,%d", &x, &y, &e) != 3)
					{
						DEBUG_PORT.println(F("DGL: invalid parameters"));
						break;
					}
					u8g2.drawGlyph(x, y, e);
					DEBUG_PORT.printf("drawGlyph x=%d y=%d code=%d" SER_NEWLINE, x, y, e);
					break;
				case CMD2INT('F','O','L'):	// FONT LIST
					// output the names of all active fonts
					for ( int i = 0; i < sizeof(font_table)/sizeof(FONT); i++)
					{
						if ( font_table[i].name[0] != 0 )
						{
							DEBUG_PORT.println(font_table[i].name);
						}
						else
						{
							DEBUG_PORT.println("END");
						}
					}
					break;
				case CMD2INT('S','T','F'):	// setFont
					if (sscanf(Command+4,  RESOLVE(MAX_TEXT_LEN), textMessage) != 1)
					{
						DEBUG_PORT.println(F("STF: invalid parameters"));
						break;
					}
					// find a font with the specified name
					int i;
					for ( i = 0; i < sizeof(font_table)/sizeof(FONT); i++)
					{
						if ( strcmp(font_table[i].name, textMessage) == 0 )
						{
							u8g2.setFont(font_table[i].bytearray);
							h = u8g2.getMaxCharHeight();
							w = u8g2.getMaxCharWidth();
							DEBUG_PORT.print("setFont ");
							DEBUG_PORT.println(textMessage);
							DEBUG_PORT.printf("getMaxCharHeight=%d getMaxCharWidth=%d" SER_NEWLINE, h, w);
							break;
						}
					}
					if ( i == sizeof(font_table)/sizeof(FONT))
					{
						DEBUG_PORT.print("STF: font name not found ");
						DEBUG_PORT.println(textMessage);
					}
					break;
				case CMD2INT('S','D','C'):	// setDrawColor
					int c;
					if (sscanf(Command+4, "%d", &c) != 1)
					{
						DEBUG_PORT.println(F("SDC: invalid parameters"));
						break;
					}
					u8g2.setDrawColor(c);
					DEBUG_PORT.print("setDrawColor ");
					DEBUG_PORT.println(c);
					break;
				case CMD2INT('D','F','R'):	// drawFrame
					if (sscanf(Command+4, "%d,%d,%d,%d", &x, &y, &w, &h) != 4)
					{
						DEBUG_PORT.println(F("DFR: invalid parameters"));
						break;
					}
					u8g2.drawFrame(x,y,w,h);
					DEBUG_PORT.print("drawFrame ");
					DEBUG_PORT.printf("x=%d y=%d w=%d h=%d" SER_NEWLINE, x, y, w, h);
					break;
				case CMD2INT('D','H','L'):	// drawHLine
					if (sscanf(Command+4, "%d,%d,%d", &x, &y, &w) != 3)
					{
						DEBUG_PORT.println(F("DHL: invalid parameters"));
						break;
					}
					u8g2.drawHLine(x,y,w);
					DEBUG_PORT.print("drawHLine ");
					DEBUG_PORT.printf("x=%d y=%d w=%d" SER_NEWLINE, x, y, w);
					break;
				case CMD2INT('D','V','L'):	// drawVLine
					if (sscanf(Command+4, "%d,%d,%d", &x, &y, &h) != 3)
					{
						DEBUG_PORT.println(F("DVL: invalid parameters"));
						break;
					}
					u8g2.drawVLine(x,y,h);
					DEBUG_PORT.print("drawVLine ");
					DEBUG_PORT.printf("x=%d y=%d h=%d" SER_NEWLINE, x, y, h);
					break;

				case CMD2INT('S','D','B'):	// sendBuffer
					u8g2.sendBuffer();
					DEBUG_PORT.println("sendBuffer");
					break;

				case CMD2INT('S','C','T'):	// setContrast
					uint8_t b;
					if (sscanf(Command+4, "%hhu", &b) != 1)
					{
						DEBUG_PORT.println(F("SCT: invalid parameters"));
						break;
					}
					u8g2.setContrast(b);
					DEBUG_PORT.print("setContrast ");
					DEBUG_PORT.println(b);
					break;
					break;

				default:
					DEBUG_PORT.print("Invalid command: ");
					DEBUG_PORT.println(Command);
			}
		}
		else	// empty line received
		{
			DEBUG_PORT.println("?");
		}
	}
	delay(10);
}
