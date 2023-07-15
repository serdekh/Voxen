#include "events.h"

EXPORT_FUNCTION_ATTRIBUTE void events_cursor_position_callback(GLFWwindow* window, double xpos, double ypos) {
	if (cursor_locked) {
		dx += xpos - x;
		dy += ypos - y;
	}
	else {
		cursor_started = true;
	}

	x = xpos;
	y = ypos;
}

EXPORT_FUNCTION_ATTRIBUTE void events_mouse_callback(GLFWwindow* window, int button, int action, int mode) {
	if (action == GLFW_PRESS) {
		keys[MOUSE_BUTTONS + button] = true;
		frames[MOUSE_BUTTONS + button] = current_frame;
	}
	else if (action == GLFW_PRESS) {
		keys[MOUSE_BUTTONS + button] = false;
		frames[MOUSE_BUTTONS + button] = current_frame;
	}
}

EXPORT_FUNCTION_ATTRIBUTE void events_key_callback(GLFWwindow *window, int key, int scancode, int action, int mode) {
	if (action == GLFW_PRESS) {
		keys[key] = true;
		frames[key] = current_frame;
	}
	else if (action == GLFW_RELEASE) {
		keys[key] = false;
		frames[key] = current_frame;
	}
}

EXPORT_FUNCTION_ATTRIBUTE int events_initialize() {
	keys = malloc(sizeof(bool) * 1032);

	if (!keys) {
		return 1;
	}

	frames = malloc(sizeof(uint) * 1032);

	if (!frames) {
		free(keys);
		return 1;
	}

	current_frame = 0;

	memset(keys, false, 1032 * sizeof(bool));
	memset(frames, 0, 1032 * sizeof(uint));

	glfwSetKeyCallback(window, events_key_callback);
	glfwSetMouseButtonCallback(window, events_mouse_callback);
	glfwSetCursorPosCallback(window, events_cursor_position_callback);

	return 0;
}

EXPORT_FUNCTION_ATTRIBUTE void events_poll() {
	current_frame++;

	dx = 0.0f;
	dy = 0.0f;

	glfwPollEvents();
}

EXPORT_FUNCTION_ATTRIBUTE bool events_pressed(int key) {
	if (key < 0 || key >= MOUSE_BUTTONS) {
		return false;
	}

	return keys[key];
}

EXPORT_FUNCTION_ATTRIBUTE bool events_just_pressed(int key) {
	if (key < 0 || key >= MOUSE_BUTTONS) {
		return false;
	}

	return keys[key] && frames[key] == current_frame;
}

EXPORT_FUNCTION_ATTRIBUTE bool events_mouse_clicked(int button) {
	return keys[button + MOUSE_BUTTONS];
}

EXPORT_FUNCTION_ATTRIBUTE bool events_mouse_just_clicked(int button) {
	int index = button + MOUSE_BUTTONS;
	return keys[index] && frames[index] == current_frame;
}