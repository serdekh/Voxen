#include <stdio.h>
#include "window.h"
#include "events.h"

#define WINDOW_TITLE "Window"
#define WINDOW_WIDTH 1280
#define WINDOW_HEIGHT 720

int main(void)
{
    if (window_initialize(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_TITLE) == 1) {
        return 1;
    }
    if (events_initialize() == 1) {
        return 1;
    }

    glClearColor(0, 0, 0, 1);

    while (!window_should_close()) {
        events_poll();

        if (events_just_pressed(GLFW_KEY_ESCAPE)) {
            window_set_should_be_closed(true);
        }

        if (events_mouse_just_clicked(GLFW_MOUSE_BUTTON_1)) {
            glClearColor(1, 0, 0, 1);
        }

        glClear(GL_COLOR_BUFFER_BIT);
        window_swap_buffers();
    }

    window_terminate();

    return 0;
}