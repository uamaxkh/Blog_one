//Перевірка, чи обрано хоч один елемент checkbox-ів з форми
//element - приймає рядок селектора для перевірки
function checkboxCheck(element) {
    if ($(element+' :checkbox:checked').length > 0) {
        return true;
    }
    else {
        alert("Не обрано жодного хобі!");
        $(element).css('background-color', '#FFE5DA');
        return false;
    }
}