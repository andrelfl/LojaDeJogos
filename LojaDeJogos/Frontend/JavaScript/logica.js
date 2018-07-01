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
        categ.appendChild(document.createTextNode(categorias[i].Nome));
        categ.id = categorias[i].id;
        categ.addEventListener("click", function () {
            trocarEcraPil(this.id);
        });
        document.querySelector("#ListaCateg").appendChild(categ);
    }
}

//Mostrar imagens fornecendo um ID
function ecraCatImg(capa) {
    var img = document.createElement("img");
    img.src = "~/"+capa;
    img.style.height = "50%";
    img.style.width = "50%";
    document.querySelector("#ListaCateg").appendChild(img);
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Pilotos
function mostraJogos(id) {
    return getJogos(id)
        .then(function (jogos) {
            backToCat();
            for (var i = 0; i < jogos.length; i++) {
                var pil = document.createElement("div");
                pil.appendChild(document.createTextNode(jogos[i].nome + " - " + jogos[i].capa));
                document.querySelector("#ListaPil").appendChild(pil);
                ecraPilImg(jogos[i].id);
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
            document.querySelector("#DataNascFal").appendChild(document.createTextNode("Data Nascimento: " + dets.birth_date + " Data Falecimento: " + dets.death_date));
            document.querySelector("#Biografia").appendChild(document.createTextNode(dets.introduction));

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