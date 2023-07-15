#pragma once

#include "OpenGL.h"
#include "export.h"

#include <stdio.h>
#include <stdbool.h>

static GLFWwindow* window;

static int window_initialize(int width, int height, const char *title);
//static void window_finalize();
static bool window_should_close();
static void window_swap_buffers();
static void window_terminate();
static void window_set_should_be_closed(bool value);

EXPORT_FUNCTION_ATTRIBUTE int API_window_initialize(int width, int height, const char* title);
EXPORT_FUNCTION_ATTRIBUTE void API_window_swap_buffers();
EXPORT_FUNCTION_ATTRIBUTE void API_window_terminate();
EXPORT_FUNCTION_ATTRIBUTE void API_window_set_should_be_closed(bool value);
EXPORT_FUNCTION_ATTRIBUTE bool API_window_should_close();