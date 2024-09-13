
function DownloadPdf(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

}

function ViewPdf(iframeid, byteBase64) {
    var link = document.getElementById(iframeid).innerHTML = "";
    var ifrm = document.createElement('iframe');

    ifrm.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    ifrm.style.width = "100%";
    ifrm.style.height = "680px";
    document.getElementById(iframeid).appendChild(ifrm);

     

}

function OpenPdfNewTab(filename, byteBase64) {

    var blob = base64Blob(byteBase64);
    var blobURL = URL.createObjectURL(blob);
    window.open(blobURL);
}

function base64Blob(b64Data) {
    sliceSize = 512;

    var byteCharacter = atob(b64Data);
    var byteArrays = [];
    for (var offset = 0; offset < byteCharacter.length; offset += sliceSize)
    {
        var slice = byteCharacter.slice(offset, offset + sliceSize);

        var byteNumber = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumber[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumber);
        byteArrays.push(byteArray);
    }

    var blob = new Blob(byteArrays, { type: 'application/pdf' });
    return blob;
}


function GetElementHtml(id) {
    var element = document.getElementById(id);
    return element.innerHTML;
}

function GetHtml() {
    return document.body.outerHTML;
}
