//Hàm đóng cửa sổ Popup
function tinyMCEClose() {
    tinyMCE.activeEditor.windowManager.close();
}

function tinyMCEInit(elemSelector, controlWidth, minheight, maxheight, uploadPageUrl) {
    tinymce.init({
        selector: elemSelector,
        plugins: [
                "advlist autolink lists link image charmap print preview hr anchor pagebreak",
                "searchreplace wordcount visualblocks visualchars code fullscreen",
                "insertdatetime media nonbreaking save table contextmenu directionality",
                "emoticons template paste textcolor"
            ], //Danh sách các Plugin
        width: controlWidth, //Chiều dài mặc định
        height: minheight,   //Chiều cao mặc định
        autoresize_min_height: minheight, //Chiều cao tối thiểu khi tự co giãn
        autoresize_max_height: maxheight, //Chiều cao tối đa khi tự co giãn
        toolbar1: "print preview code | undo redo | bold underline italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image media | forecolor backcolor emoticons",
        image_advtab: true,
        setup: function (editor) {
            editor.addMenuItem('my-image-upload', {
                icon: "image",
                text: "Upload image",
                context: "insert",
                prependToContext: !0,
                onclick: function () {
                    editor.windowManager.open({
                        title: "Upload Image",
                        url: uploadPageUrl,
                        width: 460,
                        height: 370
                    });
                }
            });
        }
    });
    $(elemSelector).focus();
}

//Hàm chèn hình vào nội dung
function tinyMCEInsertImg(url, width, height, align) {
    var imgtag = "<img src='" + url + "' alt='" + url + "'";

    if (width != "" && width != "0")
        imgtag += " width='" + width + "'";

    if (height != "" && height != "0")
        imgtag += " height='" + height + "'";

    if (align != "" && align != "0")
        imgtag += " align='" + align + "'";

    imgtag += " />";

    tinyMCE.activeEditor.selection.setContent(imgtag);
    tinyMCE.activeEditor.windowManager.close();
}