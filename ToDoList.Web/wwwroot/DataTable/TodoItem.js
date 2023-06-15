﻿"use strict";
// Class definition

var KTDatatableAutoColumnHideDemo = function () {
    // Private functions

    var demo = function () {

        var datatable = $('#kt_datatable').KTDatatable({

            data: {
                type: 'remote',
                source: {
                    read: {
                        url: 'ToDoItem/GetToDoItemData',
                    },
                },
                pageSize: 10,
                saveState: false,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true,
            },

            layout: {
                scroll: false
            },

            sortable: true,

            pagination: true,

            search: {
                input: $('#kt_datatable_search_query'),
                key: 'generalSearch'
            },

            columns: [{
                field: 'id',
                title: 'رقم',
                width: '50'
            },
            {
                field: 'title',
                title: 'عنوان المهمة',
                width: 'auto'
            },
            {
                field: 'notes',
                title: 'ملاحظات المهمة',
                width: 'auto'
            },
             {
                field: 'priority',
                title: 'اهمية المهمة',
                width: 'auto'
            },
            {
                field: 'status',
                title: 'الحالة',
                width: 'auto'
            },
            {
                field: 'dueDate',
                title: 'تاريخ استحقاق المهمة',
                width: 'auto'
            },
            {
            field: 'toDoList.title',       
            title: 'المهمة الرئيسية العامة', 
            width: 'auto'
            },
            {
                field: 'createAt',
                title: 'تاريخ التسجيل ', 
                width: 'auto'
            }
                ,
            {
                field: 'Actions',
                title: 'العمليات',
                sortable: false,
                width: 125,
                overflow: 'visible', 
                autoHide: false,
                template: function (data) { 
                    var buttons = ''; 
                    buttons = buttons + '';
                    buttons = buttons + '\<a  href ="/ToDoItem/Update/' + data.id + '" class="PopUp btn btn-sm btn-clean btn-icon mr-2" title="تعديل  بيانات ' + data.title + ' ">\
                            <span class="svg-icon svg-icon-warning svg-icon-md">\
                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
                                        <rect x="0" y="0" width="24" height="24"/>\
                                        <path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero"\ transform="translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) "/>\
                                        <rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1"/>\
                                    </g>\
                                </svg>\
                            </span>\
                        </a>\
                        <a href ="/ToDoItem/Delete/' + data.id + '" tname="#kt_datatable" class="Confirm btn btn-sm btn-clean btn-icon" title="Delete">\
                            <span class="svg-icon svg-icon-danger svg-icon-danger svg-icon-md">\
                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
                                        <rect x="0" y="0" width="24" height="24"/>\
                                        <path d="M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z" fill="#000000" fill-rule="nonzero"/>\
                                        <path d="M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3"/>\
                                    </g>\
                                </svg>\
                            </span>\
                        </a>';
                    if (data.status == 'unfinished') {
                        buttons = buttons + '<a href="/ToDoItem/UpdateStatus/' + data.id + '" tname="#kt_datatable" class="Confirm btn btn-sm btn-clean btn-icon" title=" موافقة الإكتمال" >\
                            <span class="svg-icon svg-icon-success svg-icon-2x"><!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2021-05-14-112058/theme/html/demo1/dist/../src/media/svg/icons/Code/Done-circle.svg--><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
                                <g stroke="none" stroke - width="1" fill = "none" fill - rule="evenodd" >\
                                <rect x="0" y="0" width="24" height="24" />\
                                <circle fill="#000000" opacity="0.3" cx="12" cy="12" r="10" />\
                                <path d="M16.7689447,7.81768175 C17.1457787,7.41393107 17.7785676,7.39211077 18.1823183,7.76894473 C18.5860689,8.1457787 18.6078892,8.77856757 18.2310553,9.18231825 L11.2310553,16.6823183 C10.8654446,17.0740439 10.2560456,17.107974 9.84920863,16.7592566 L6.34920863,13.7592566 C5.92988278,13.3998345 5.88132125,12.7685345 6.2407434,12.3492086 C6.60016555,11.9298828 7.23146553,11.8813212 7.65079137,12.2407434 L10.4229928,14.616916 L16.7689447,7.81768175 Z" fill="#000000" fill-rule="nonzero" />\
                         </g >\
                         </svg >\
                         </span >\
                         </span >\
                         </a >';;
                    }
                    return buttons;
                },
            }],
        });

        $('#kt_datatable_search_status').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Status');
        });

        $('#kt_datatable_search_type').on('change', function () {
            datatable.search($(this).val().toLowerCase(), 'Type');
        });

        $('#kt_datatable_search_status, #kt_datatable_search_type').selectpicker();
    };

    return {
        // public functions
        init: function () {
            demo();
        },
    };
}();

jQuery(document).ready(function () {
    KTDatatableAutoColumnHideDemo.init();
});

$('#excelBtn').on('click', function () {
    $.post('level/ExportToExcel', {
        generalSearch: $('#kt_datatable_search_query').val().toLowerCase()
    },
        function (returnedData) {
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
            var yyyy = today.getFullYear();

            today = mm + '/' + dd + '/' + yyyy;

            var a = document.createElement('a');
            a.href = returnedData;
            a.download = today + '-report.xlsx';
            document.body.append(a);
            a.click();
            a.remove();
        });
});