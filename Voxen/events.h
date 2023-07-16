#pragma once

#include "window.h"

#include <stdlib.h>
#include <memory.h>

#define MOUSE_BUTTONS 1024

typedef unsigned int uint;

static bool *keys = NULL;
static uint *frames = NULL; 
static uint current_frame = 0;

static double dx = 0;
static double dy = 0;
static double x = 0;
static double y = 0;

static bool cursor_started = false;
static bool cursor_locked = false;

void events_key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);
void events_mouse_callback(GLFWwindow* window, int button, int action, int mode);
void events_cursor_position_callback(GLFWwindow * window, double xpos, double ypos);

EXPORT_FUNCTION_ATTRIBUTE int events_initialize();
EXPORT_FUNCTION_ATTRIBUTE void events_finalize();

EXPORT_FUNCTION_ATTRIBUTE void events_poll();

EXPORT_FUNCTION_ATTRIBUTE bool events_pressed(int key);
EXPORT_FUNCTION_ATTRIBUTE bool events_just_pressed(int key);
EXPORT_FUNCTION_ATTRIBUTE bool events_mouse_clicked(int button);
EXPORT_FUNCTION_ATTRIBUTE bool events_mouse_just_clicked(int button);
