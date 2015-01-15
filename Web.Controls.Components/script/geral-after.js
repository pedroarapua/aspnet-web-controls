function ValidatorUpdateDisplay(val) {
    if (typeof(val.display) == "string") {
        if (val.display == "None") {
            return;
        }
        if (val.display == "Dynamic") {
            val.style.display = val.isvalid ? "none" : "inline";
            if(val.isvalid)
                $(val.childNodes[0]).tooltip('close');
            else
                $(val.childNodes[0]).tooltip('open');
            return;
        }
    }
    if ((navigator.userAgent.indexOf("Mac") > -1) &&
        (navigator.userAgent.indexOf("MSIE") > -1)) {
        val.style.display = "inline";
    }
    val.style.visibility = val.isvalid ? "hidden" : "visible";
    if(val.isvalid)
        $(val.childNodes[0]).tooltip('close');
    else
        $(val.childNodes[0]).tooltip('open');
}
