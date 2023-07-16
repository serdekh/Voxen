#include "window.h"

EXPORT_FUNCTION_ATTRIBUTE int window_initialize(int width, int height, const char* title) {
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
    glfwWindowHint(GLFW_RESIZABLE, GL_FALSE);

    window = glfwCreateWindow(width, height, title, 0, 0);

    if (!window) {
        glfwTerminate();
        return 1;
    }

    glfwMakeContextCurrent(window);

    glewExperimental = GL_TRUE;

    if (glewInit() != GLEW_OK) {
        fprintf(stderr, "Error: failed to initialize libraries");
        glfwTerminate();
        return 1;
    }

    glViewport(0, 0, width, height);

    return 0;
}

EXPORT_FUNCTION_ATTRIBUTE bool window_should_close() {
    return glfwWindowShouldClose(window);
}

EXPORT_FUNCTION_ATTRIBUTE void window_swap_buffers() {
    glfwSwapBuffers(window);
}

EXPORT_FUNCTION_ATTRIBUTE void window_terminate() {
    glfwTerminate();
}

EXPORT_FUNCTION_ATTRIBUTE void window_set_should_be_closed(bool value) {
    glfwSetWindowShouldClose(window, value);
}