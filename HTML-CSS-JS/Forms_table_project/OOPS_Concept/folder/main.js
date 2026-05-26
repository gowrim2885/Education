document.addEventListener("DOMContentLoaded", function () {

    const edit_id = localStorage.getItem("edit-id");
    
   
    const service = new StudentService();
    const table = new Table(service, edit_id);
    const form = new Form(table, service);

    if(edit_id){
        table.editRow();
    }

    
    table.DisplayTable();

    // const search = document.getElementById("search-data");
    // search.addEventListener('input', function(){
    //     const filter_data = search.value.toLowerCase();
    //     localStorage.setItem('tablefilter', filter_data);
    //     table.GetFilterData();
    // });

    const Add_Button = document.getElementById("add_button");
    Add_Button?.addEventListener('click', (e) => {
        e.preventDefault();
        form.getFormData()
    });

    const sort_assecnding = document.getElementById('sortaz');
    sort_assecnding?.addEventListener('click', (e) => {
        e.preventDefault();
        table.SortAZ();
    });

    const sort_desending = document.getElementById('sortza');
    sort_desending?.addEventListener('click', (e) => {
        e.preventDefault();
        table.SortZA();
    });
});
