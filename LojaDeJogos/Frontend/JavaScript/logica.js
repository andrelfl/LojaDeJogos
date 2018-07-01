document.addEventListener('DOMContentLoaded', function main() { 
    ecraCategorias();
    //mostraDetPilotos("colinmcrae");
});

////Categorias
function ecraCategorias() {
    return getCategorias()
        .then(function (categorias) {
            mostraCategorias(categorias);
        })
        .catch(function (erro) {
            console.error(erro);
        });
}

//Percorrer e mostrar todas as descricoes e imagens
function mostraCategorias(categorias) {
    for (var i = 0; i < categorias.length; i++) {
        var categ = document.createElement("div");
        console.log(categorias.ListaDeJogos);
        categ.appendChild(document.createTextNode(categorias[i].Nome + " - "));
        categ.id = categorias[i].id;
        categ.addEventListener("click", function () {
            trocarEcraPil(this.id);
        });
        document.querySelector("#ListaCateg").appendChild(categ);
        //ecraCatImg(categorias[i].id);
    }
}

//Mostrar imagens fornecendo um ID
function ecraCatImg(id) {
    var img = document.createElement("img");
    img.src = getImg(id);
    img.style.height = "50%";
    img.style.width = "50%";
    document.querySelector("#ListaCateg").appendChild(img);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Pilotos
function mostraPilotos(id) {
    return getPilotos(id)
        .then(function (pilotos) {
            backToCat();
            for (var i = 0; i < pilotos.length; i++) {
                var pil = document.createElement("div");
                pil.appendChild(document.createTextNode(pilotos[i].name + " - " + pilotos[i].nationality));
                document.querySelector("#ListaPil").appendChild(pil);
                ecraPilImg(pilotos[i].id);
            }
        })
        .catch(function (erro) {
            console.error(erro);
        });
}

function ecraPilImg(id) {
    var img = document.createElement("img");
    img.src = getPilImg(id);
    img.style.height = "25%";
    img.style.width = "25%";
    document.querySelector("#ListaPil").appendChild(img);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Mudar ecra

function trocarEcraPil(id) {
    document.querySelector("#ListaCateg").style = "display: none;";
    document.querySelector("#ListaPil").style = "display:;";
    mostraPilotos(id);
}

function backToCat() {
    var btn = document.createElement("BUTTON");
    btn.appendChild(document.createTextNode("Back"));
    document.querySelector("#ListaPil").appendChild(btn);
    btn.addEventListener("click", function () {
        document.querySelector("#ListaCateg").style = "display:;";
        document.querySelector("#ListaPil").innerHTML = "";
    });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///DetalhesPilotos

function mostraDetPilotos(id) {
    return getPilDet(id)
        .then(function (dets) {
            document.querySelector("#Nome").appendChild(document.createTextNode(dets.name));
            document.querySelector("#Alcunha").appendChild(document.createTextNode(dets.nickname));
            //document.querySelector("#Fotografia").appendChild(document.createTextNode(dets.name));
            document.querySelector("#DataNascFal").appendChild(document.createTextNode("Data Nascimento: " + dets.birth_date + " Data Falecimento: " + dets.death_date));
            //document.querySelector("#Campeonato").appendChild(document.createTextNode(dets.name));
            document.querySelector("#Biografia").appendChild(document.createTextNode(dets.introduction));
            //document.querySelector("#Carreira").appendChild(document.createTextNode(dets.name));
            //document.querySelector("#MultPil").appendChild(document.createTextNode(dets.name));
        })
        .catch(function (erro) {
            console.error(erro);
        });
}

function ecraPilDetImg(idPil, idImg) {
    var img = document.createElement("img");
    img.src = getPilDetImg(idPil, idImg);
    img.style.height = "25%";
    img.style.width = "25%";
    document.querySelector("#MultPil").appendChild(img);
}



