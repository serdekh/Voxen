#pragma once

#include "OpenGL.h"
#include "export.h"

#include <stdio.h>
#include <stdbool.h>

GLFWwindow* window;

EXPORT_FUNCTION_ATTRIBUTE int window_initialize(int width, int height, const char *title);
EXPORT_FUNCTION_ATTRIBUTE bool window_should_close();
EXPORT_FUNCTION_ATTRIBUTE void window_swap_buffers();
EXPORT_FUNCTION_ATTRIBUTE void window_terminate();
EXPORT_FUNCTION_ATTRIBUTE void window_set_should_be_closed(bool value);