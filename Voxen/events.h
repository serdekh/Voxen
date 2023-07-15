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

static int events_initialize();

static void events_poll();
static void events_key_callback(GLFWwindow* window, int key, int scancode, int action, int mode);
static void events_mouse_callback(GLFWwindow* window, int button, int action, int mode);
static void events_cursor_position_callback(GLFWwindow * window, double xpos, double ypos);

static bool events_pressed(int key);
static bool events_just_pressed(int key);
static bool events_mouse_clicked(int button);
static bool events_mouse_just_clicked(int button);