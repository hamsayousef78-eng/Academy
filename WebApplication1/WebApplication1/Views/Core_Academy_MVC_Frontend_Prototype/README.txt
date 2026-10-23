CORE ACADEMY — MVC-FRIENDLY STATIC HTML PROTOTYPE

This version intentionally contains NO JavaScript.

Run it:
1. Extract the ZIP file.
2. Open index.html in your browser.
3. Use the sidebar links to navigate pages.
4. On Courses, click Add course; it opens course-create.html.
5. Click Details/Edit/Delete links in the table to open separate pages.

Pages included:
- index.html: dashboard
- courses.html: courses list
- course-create.html: create form
- course-details.html: course details
- course-edit.html: edit form with sample values
- course-delete.html: delete confirmation page
- instructors.html, students.html, rounds.html
- enrollments.html, reports.html, settings.html
- styles.css: shared styling

Important:
- This is a static HTML/CSS prototype with no JavaScript and no backend.
- Forms are not connected or persisted yet; the form structure and field names are prepared for later MVC integration.
- When integrating into ASP.NET Core MVC, move the shared sidebar/topbar/footer and common markup to Views/Shared/_Layout.cshtml, then replace static href links with asp-controller/asp-action Tag Helpers, and bind forms to real Actions.
