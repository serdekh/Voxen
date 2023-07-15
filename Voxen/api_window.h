#pragma once

#include "export.h"

#include <stdbool.h>

EXPORT_API
int window_api_initialize(int width, int height, const char* title);

EXPORT_API
bool window_api_should_close();

EXPORT_API
void window_api_swap_buffers();

EXPORT_API
void window_api_terminate();

EXPORT_API
void window_api_set_should_be_closed(bool value);