
function resetBTN() {
    var form = document.getElementById("edition_form");
    //console.log(form);
    //form.reset();

    form.action = "School/Create"
    location.reload(); 
    
    /*console.log(form);*/
}
try {
    var btn = document.getElementById("reset_btn")
    btn.addEventListener("click", resetBTN)
}
catch(e){
    //console.log(e.Message)
}


var delete_form = document.getElementsByClassName("delete_form")

for (let form of delete_form) {
    //console.log(form)
    form.addEventListener("submit", (e) => {
        e.preventDefault();
        let id = e.target[0].value
        fetch(`School/Delete/${id}`, {
            method: 'GET'
        }).then((resp) => {
            alert("Record Deleted!");
            location.reload();  
        }).catch((err) => { 
            console.log(err);
        });
    });
}
       
