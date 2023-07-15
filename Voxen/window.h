#pragma once

#include "OpenGL.h"

#include <stdio.h>
#include <stdbool.h>

static GLFWwindow* window;

static int window_initialize(int width, int height, const char *title);
//static void window_finalize();
static bool window_should_close();
static void window_swap_buffers();
static void window_terminate();
static void window_set_should_be_closed(bool value);