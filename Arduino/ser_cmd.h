#define DEBUG_PORT  Serial

#define MIN_CMD_LEN 3
#define MAX_CMD_LEN	100
#define SER_TIMEOUT 1000    // 1 s

#define SER_NEWLINE "\r\n"

void SER_init(unsigned long ser_baud, uint32_t ser_config);
void SER_init(unsigned long ser_baud, uint32_t ser_config, int8_t rx_pin, int8_t tx_pin);
