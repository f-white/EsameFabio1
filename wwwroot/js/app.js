﻿function CreateUser() {
    var body = {};
    body.UserName = document.querySelector("#UserName").value;
    body.Email = document.querySelector("#Email").value;
    body.FirstName = document.querySelector("#FirstName").value;
    body.LastName = document.querySelector("#LastName").value;
    body.Password = document.querySelector("#Password").value;
    body.ConfirmPassword = document.querySelector("#ConfirmPassword").value;

    $.ajax({
        method: "POST",
        url: "/api/Api/CreateUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (response, status) {
            textP = document.createElement("p");
            textP.style.textAlign = "center";
            textP.innerText = response;
            if (response == "OK") {
                document.getElementById("CreateUserModalResult").innerHTML = `
                    <div class="alert alert-success alert-dismissible fade show mt-3" role="alert">
                        <strong>Benvenuto!</strong>
                        <p>Sei stato registrato con successo.</p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>`;
               
                window.setTimeout(refreshPage, 1000);
            }
            else {
                document.getElementById("CreateUserModalResult").innerHTML = `
                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
                        <strong>Registrazione fallita :(</strong>
                        <p>${response}</p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>`;

            }
          
           
            this.always();
        },
        error: function (error, status) {
            document.getElementById("CreateUserModalResult").innerHTML = `
                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
                        <strong>Registrazione fallita :(</strong>
                        <p>Email o password non corrette. La password deve avere almeno 6 caratteri e la mail la @</p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>`;
            this.always();
        },
        always: function () {
            document.getElementById("CreateUserForm").reset();
        }
    });
};



function LoginUser() {
    var body = {};
    body.UserName = document.querySelector("#LoginUserName").value;
    body.Password = document.querySelector("#LoginPassword").value;
    $.ajax({
        method: "POST",
        url: "/api/Api/LoginUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (response, status) {
            textP = document.createElement("p");
            textP.style.textAlign = "center";
            textP.innerText = response;
            if (response == "OK") {
                document.getElementById("LoginUserModalResult").innerHTML = `
                    <div class="alert alert-success alert-dismissible fade show mt-3" role="alert">
                        <strong>Benvenuto!</strong>
                        <p>Sei stato loggato con successo.</p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
            `;
                
                window.setTimeout(refreshPage, 1000);
            }
            else {
                document.getElementById("LoginUserModalResult").innerHTML = `
                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
                        <strong>Login fallita :(</strong>
                        <p>${response}</p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
            `;

            }

           
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
            document.getElementById("LoginUserForm").reset();
          

        }
    });
};


function LogoutUser() {
    var body = {};
    $.ajax({
        method: "POST",
        url: "/api/Api/LogoutUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (response, status) {

          
            window.location = "/";
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
          

        }
    });
};

function prenotaAttivita(userId, idAttivita) {
    var body = {};
    body.IdUtente = userId;
    body.IdAttivita = idAttivita;
    console.log(body);
    $.ajax({
        url: "/api/Api/PrenotaAttivita",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            IdUtente: userId,
            IdAttivita: idAttivita
        }),
        dataType: "json",
        success: function (response) {
            // Gestisci la risposta qui se necessario
            console.log(response);
            alert("Prenotazione effettuata");
            window.location.href = "/Home/Attivita";  //modificato aggiungendo "prenotate"
        },
        error: function (error) {
            // Gestisci l'errore qui se necessario
            console.log(error);
            alert("Prenotazione effettuata");
            window.location.href = "/Home/Attivita";
        }
    });
}
function deleteAttivita(IdPrenotazioneAttivita) {
    var body = {};
    body.IdPrenotazioneAttivita = IdPrenotazioneAttivita;
    $.ajax({
        method: "POST",
        url: "/api/Api/DeleteAttivita",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
            window.location = window.location;
        }
    });
};
//function PrenotaUser(idCrossAttrazionePeriodo, indice) {
   
//    var body = {};
//    body.numPosti = document.getElementById("#" + indice + "numeroPostiScelti").value;
//    body.Id = idCrossAttrazionePeriodo;
//    console.log(body);
//    $.ajax({
//        method: "POST",
//        url: "/api/Api/PrenotaUser",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (response, status) {
//            textP = document.createElement("p");
//            textP.style.textAlign = "center";
//            textP.innerText = response;
//            if (response == "OK") {
//                document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-success">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Buon viaggio!</strong>
//                        <p>La tua prenotazione è avvenuta con successo.</p>
//                    </div>`;
               

//                setTimeout(() => {
//                    window.location.replace('/Prenotazione/Prenotazioni');
//                },1000)
//                //window.setTimeout( window.location.replace('/Prenotazione/Prenotazioni') , 5000);
               
//            }
//            else {
//                document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-danger">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Prenotazione fallita!</strong>
//                        <p>Non ci sono abbastanza posti disponibili oppure hai scelto 0 posti!</p>
//                    </div>`;
//            }


//            this.always();
//        },
//        error: function (error, status) {
//            console.log("sono in error del js", error);
//            document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
//                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Prenotazione fallita :(</strong>
//                        <p>Errore nella prenotazione</p>
                        
//                    </div>`;
//            this.always();
//        },
//        always: function () {


           
//        }
//    });
//};



//function ModificaPosti(idPrenotazione, indice) {

//    var body = {};
//    body.NumPostiPrenotati = document.getElementById("#" + indice + "numeroPostiModificati").value;
//    body.Id = idPrenotazione;
//    console.log(body);
//    $.ajax({
//        method: "POST",
//        url: "/api/Api/ModificaPosti",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (response, status) {
//            textP = document.createElement("p");
//            textP.style.textAlign = "center";
//            textP.innerText = response;
//            if (response == "OK") {
//                document.getElementById("ModificaPostiResult").innerHTML = `
//                    <div class="alert alert-success">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Buon viaggio!</strong>
//                        <p>La tua modifica è avvenuta con successo.</p>
//                    </div>`;


//                setTimeout(() => {
//                    window.location.reload();
//                }, 1000)
//                //window.setTimeout( window.location.replace('/Prenotazione/Prenotazioni') , 5000);

//            }
//            else {
//                document.getElementById("ModificaPostiResult").innerHTML = `
//                    <div class="alert alert-danger">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Modifica fallita!</strong>
//                        <p>Non ci sono abbastanza posti disponibili oppure hai scelto 0 posti!</p>
//                    </div>`;
//            }


//            this.always();
//        },
//        error: function (error, status) {
//            console.log("sono in error del js", error);
//            document.getElementById("ModificaUserResult").innerHTML = `
//                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Modifica fallita :(</strong>
//                        <p>Errore nella modifica</p>
                       
//                    </div>`;
//            this.always();
//        },
//        always: function () {



//        }
//    });
//};

//function CancellaPrenotazione(idPrenotazione) {

//    var body = {};
//    body.Id = idPrenotazione;
//    console.log(body);
//    $.ajax({
//        method: "POST",
//        url: "/api/Api/CancellaPrenotazione",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (response, status) {
//            textP = document.createElement("p");
//            textP.style.textAlign = "center";
//            textP.innerText = response;
//            if (response == "OK") {
//                document.getElementById("ModificaPostiResult").innerHTML = `
//                    <div class="alert alert-success">
//                        <strong>Eliminazione avvenuta con successo!</strong>
//                    </div>`;


//                setTimeout(() => {
//                    window.location.reload();
//                }, 1000)

//            }
//            else {
//                document.getElementById("ModificaPostiResult").innerHTML = `
//                    <div class="alert alert-danger">
//                        <strong>Cancellazione fallita!</strong>
//                        <p>Qualcosa è andato storto</p>
//                    </div>`;
//            }


//            this.always();
//        },
//        error: function (error, status) {
//            console.log("sono in error del js", error);
//            document.getElementById("ModificaUserResult").innerHTML = `
//                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
//                        <strong>Cancellazione fallita :(</strong>
//                        <p>Qualcosa è andato storto</p>
//                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                    </div>`;
//            this.always();
//        },
//        always: function () {



//        }
//    });
//};

//function CancellaCrossAttrazionePeriodo(idCross) {

//    var body = {};
//    body.Id = idCross;
//    console.log(body);
//    $.ajax({
//        method: "POST",
//        url: "/api/Api/CancellaCrossAttrazionePeriodo",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (response, status) {
//            textP = document.createElement("p");
//            textP.style.textAlign = "center";
//            textP.innerText = response;
//            if (response == "OK") {
//                document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-success">
//                      <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Eliminazione avvenuta con successo!</strong>
//                    </div>`;


//                setTimeout(() => {
//                    window.location.reload();
//                }, 2000)

//            }
//            else {
//                document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-danger">
//                     <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Cancellazione fallita!</strong>
//                        <p>Non è possibile eliminare un periodo se ci sono delle prenotazioni effettuate</p>
                       
//                    </div>`;
//            }


//            this.always();
//        },
//        error: function (error, status) {
//            console.log("sono in error del js", error);
//            document.getElementById("PrenotaUserResult").innerHTML = `
//                    <div class="alert alert-danger alert-dismissible fade show mt-3" role="alert">
//                         <button type="button" class="close" data-dismiss="alert" aria-label="Close">
//                            <span aria-hidden="true">&times;</span>
//                        </button>
//                        <strong>Cancellazione fallita:(</strong>
//                        <p>Qualcosa è andato storto</p>
                       
//                    </div>`;
//            this.always();
//        },
//        always: function () {

           


//        }
//    });
//};

function insertAtt() {
    var body = {};
    body.NomeAttivita = $('#NomeAtt').val();
    body.DescrizioneAttivita = $('#DescrizioneAtt').val();
    body.DataInizio = $('#DataInizioAtt').val();
    body.DataFine = $('#DataFineAtt').val();
    body.NumeroPosti = parseInt($('#PostiAtt').val()); //importante parsificare il testo!!!
    body.PrezzoAttivita = parseFloat($('#PrezzoAtt').val()); //importante parsificare il testo!!!
    body.ImgAtt = $('#ImgAtt').val();
    $.ajax({
        method: "POST",
        url: "/api/Api/InsertAtt",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
};

//function deleteAtt() {
//    var body = {};
//    body.idAttivita = $('idAttivita').val();
//    $.ajax({
//        method: "POST",
//        url: "/api/api/DeleteAtt",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (data, status) {
//            console.log(body);
//            console.log(data);
//            console.log(status);
//            this.always();
//        },
//        error: function (error, status) {
//            console.log(body);
//            console.log(error);
//            console.log(status);
//            this.always();
//        },
//        always: function () { }
//    });
//};

function deleteAttById(id) {
    var body = {};
    body.idAttivita = id;
    $.ajax({
        method: "POST",
        url: "/api/api/DeleteAtt",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () {
            window.location = window.location;
        }
    });
};
function updateAttById(id) {
    document.getElementById("modal-header-upd").innerText = "Aggiorna Valori"
    nameP = document.createElement("p");
    nameP.style.textAlign = "left";
    nameP.innerText = 'Nome Attività';
    document.getElementById("modal-body-upd").appendChild(nameP);
    nameTextArea = document.createElement("input");
    nameP.appendChild(nameTextArea);

    DescrP = document.createElement("p");
    DescrP.style.textAlign = "left";
    DescrP.innerText = 'Descrizione Attività';
    document.getElementById("modal-body-upd").appendChild(DescrP);
    DescrTextArea = document.createElement("input");
    DescrP.appendChild(DescrTextArea);

    DataInizioP = document.createElement("p");
    DataInizioP.style.textAlign = "left";
    DataInizioP.innerText = 'Data Inizio';
    document.getElementById("modal-body-upd").appendChild(DataInizioP);
    DataInizioTextArea = document.createElement("input");
    DataInizioTextArea.setAttribute("type", "date");
    DataInizioP.appendChild(DataInizioTextArea);

    DataFineP = document.createElement("p");
    DataFineP.style.textAlign = "left";
    DataFineP.innerText = 'Data Fine';
    document.getElementById("modal-body-upd").appendChild(DataFineP);
    DataFineTextArea = document.createElement("input");
    DataFineTextArea.setAttribute("type", "date");
    DataFineP.appendChild(DataFineTextArea);

    PostiP = document.createElement("p");
    PostiP.style.textAlign = "left";
    PostiP.innerText = 'Posti';
    document.getElementById("modal-body-upd").appendChild(PostiP);
    PostiTextArea = document.createElement("input");
    PostiTextArea.setAttribute("type", "number");
    PostiP.appendChild(PostiTextArea);

    PrezzoP = document.createElement("p");
    PrezzoP.style.textAlign = "left";
    PrezzoP.innerText = 'Prezzo';
    document.getElementById("modal-body-upd").appendChild(PrezzoP);
    PrezzoTextArea = document.createElement("input");
    PrezzoP.appendChild(PrezzoTextArea);

    ImgAttP = document.createElement("p");
    ImgAttP.style.textAlign = "left";
    ImgAttP.innerText = 'Link immagine';
    document.getElementById("modal-body-upd").appendChild(ImgAttP);
    ImgTextArea = document.createElement("input");
    ImgAttP.appendChild(ImgTextArea);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.id = "modalOKButton";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.idAttivita = id;
        body.NomeAttivita = nameTextArea.value;
        body.DescrizioneAttivita = DescrTextArea.value;
        body.DataInizio = DataInizioTextArea.value;
        body.DataFine = DataFineTextArea.value;
        body.numeroPosti = parseInt(PostiTextArea.value);
        body.PrezzoAttivita = parseFloat(PrezzoTextArea.value);
        body.ImgAtt = ImgAttP.value;
        $.ajax({
            method: "POST",
            url: "/api/api/UpdateAtt",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
                window.location = window.location;
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.id = "modalCancelButton";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    document.getElementById("modal-upd").style.display = "block";
};

function hideModal() {
    document.getElementById("modal-header-upd").innerText = "";
    $(".modal-body-upd").empty();
    $(".modal-footer").empty();
    document.getElementById("modal-upd").style.display = "none";
}
function refreshPage() {


    location.reload(true);
}