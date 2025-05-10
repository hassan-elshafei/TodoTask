document.addEventListener('DOMContentLoaded', function () {
    // Delete Modal
    var deleteModal = document.getElementById('deleteModal');
    if (deleteModal) {
        deleteModal.addEventListener('show.bs.modal', function (event) {
            var button = event.relatedTarget;
            var taskId = button.getAttribute('data-taskid');
            var taskTitle = button.getAttribute('data-tasktitle');

            document.getElementById('taskTitle').textContent = taskTitle;
            document.getElementById('taskIdToDelete').value = taskId;
        });
    }

    // Initialize Create Modal
    var createModal = new bootstrap.Modal(document.getElementById('createTaskModal'));

    // Handle Create Button Click - Load form when modal opens
    document.getElementById('createTaskModal').addEventListener('show.bs.modal', function () {
        fetch(document.getElementById('CreateButton').getAttribute('data-url'), {
            headers: { 'X-Requested-With': 'XMLHttpRequest' }
        })
            .then(response => response.text())
            .then(html => {
                document.getElementById('createTaskModalBody').innerHTML = html;
                initCreateForm();
            });
    });

    function initCreateForm() {
        var form = document.getElementById('CreateTodoForm');
        if (form) {
            form.addEventListener('submit', function (e) {
                e.preventDefault();

                // Show loading state
                var submitButton = form.querySelector('button[type="submit"]');
                var originalText = submitButton.innerHTML;
                submitButton.innerHTML = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> @L["Saving"].Value...';
                submitButton.disabled = true;

                fetch(form.action, {
                    method: 'POST',
                    body: new FormData(form),
                    headers: {
                        'X-Requested-With': 'XMLHttpRequest',
                        'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                    }
                })
                    .then(response => {
                        if (response.ok) {
                            return response.json();
                        }
                        return response.text().then(text => { throw new Error(text) });
                    })
                    .then(data => {
                        if (data.success) {
                            createModal.hide();
                            window.location.reload();
                        } else {
                            document.getElementById('createTaskModalBody').innerHTML = data;
                            initCreateForm();
                        }
                    })
                    .catch(error => {
                        console.error('Error submitting form:', error);
                        document.getElementById('createTaskModalBody').innerHTML =
                            '<div class="alert alert-danger">@L["SaveError"].Value</div>' +
                            document.getElementById('createTaskModalBody').innerHTML;
                    })
                    .finally(() => {
                        submitButton.innerHTML = originalText;
                        submitButton.disabled = false;
                    });
            });
        }
    }
});