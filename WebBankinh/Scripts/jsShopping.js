$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var soluong = 1;
        var tSoLuong = $('#soluong_value').text();
        if (tSoLuong != '') {
            soluong = parseInt(tSoLuong);
        }
        $.ajax({
            url: '/shoppingcart/AddToCart',
            type: 'POST',   
            data: { id: id, soluong: soluong },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    /*alert(rs.msg);*/
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {  
        e.preventDefault();
        var id = $(this).data("id");
        var soluong = $('#SoLuong_' + id).val();
        Update(id, soluong);
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có chắc muốn xóa tất cả sản phẩm có trong giỏ hàng?');
        if (conf == true) {
            DeleteAll();
        }
    });

    $('body').on('click', '.btnDelete', function (e) { 
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart();
                    }
                }
            });
        }

    });
});



function ShowCount() { //trả về số lượng hàng được thêm
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/DeleteAll',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function Update(id,soluong) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: { id: id, soluong: soluong },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function LoadCart() { //hiển thị giỏ hàng
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}