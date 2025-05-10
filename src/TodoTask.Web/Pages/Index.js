$(function () {
    abp.log.debug('Index.js initialized!');

    // Initialize tooltips
    $('[title]').tooltip();

    // Date range validation
    $('#filterForm').submit(function (e) {
        const fromDate = new Date($('#FromDateFilter').val());
        const toDate = new Date($('#ToDateFilter').val());

        if ($('#FromDateFilter').val() && $('#ToDateFilter').val() && fromDate > toDate) {
            abp.notify.error('To Date must be greater than From Date', 'Invalid Date Range');
            return false;
        }
        return true;
    });

    // Auto-submit when date fields change (optional)
    $('.date-filter').change(function () {
        if ($(this).val()) {
            $('#filterForm').submit();
        }
    });
});