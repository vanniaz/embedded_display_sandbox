# How to implement new commands

If you are willing to contribute by implementing new commands, here are a few tips:

1. The sandbox command interpreter is basically a big "switch" statement, where each "case" handles a specific command. Commands are identified by a 3-letter code, but C++ doesn't allow to use strings for "case" statements, so a macro is used to convert the 3 characters to an integer value, like this:
    
    `case CMD2INT('D','S','T'):	// drawStr`

3. Decide what 3-letter code you want to use for the new command (e.g. if you want to implement "drawXBMP" you could use the code "DXB"), and add the relative case statement:
    
    `case CMD2INT('D','X','B'):	// drawXBMP`

5. Handle the parsing of the command inside the case statement. This should be rather easy if you look at how the code handles other commands with a `sscanf`.

6. On the Windows side, you don't need to recompile the code, you just need to add the new command to the commands.csv file, which is formatted like this:
    
    `3-letter-ID;function-template;function-prototype`
    
    Example: `DHL;drawHLine(x,y,w);void U8G2::drawHLine(u8g2_uint_t x, u8g2_uint_t y, u8g2_uint_t w)`
   
    You can take the function prototype definition from the U8g2 reference: https://github.com/olikraus/u8g2/wiki/u8g2reference

7. Once you have implemented and tested the new commands, you can issue a pull request.
   

