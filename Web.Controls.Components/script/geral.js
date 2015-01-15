var util = {
	/* atributos */
	params: {},
	url: '',
	path: '',
	callback: function (methodName, fn) {
		var urlChamada = this.path + this.url + "?dtRequest=" + new Date() + "&methodName=" + methodName + "&params= " + JsonToString(this.params);
		this.params = {};
		$.ajax(
        {
        	async: true,
        	url: urlChamada,
        	dataType: "json",
        	contentType: "application/json; charset=utf-8",
        	success: function (data, b, c) {
        	    
        		if (data.errorAjax){
        		    fctEscondeCarregando();
        			alert(data.errorAjax);
        		}else
        			fn(data);
        	}
        }
        );
	},
	addParameter: function (name, value, type) { this.params[name] = type == 'static' ? value : eval(value); },
	setUrl: function(url){ this.url = url; },
	setPath: function(path){ this.path = path; },
	setParams: function(params){ this.params = params; }
};


 /*Fun�o que permite apenas numeros*/
function maskNumber(cmp){
    var v = cmp.value;
    cmp.value = v.replace(/\D/g,"");
}

/*Fun��o que padroniza telefone (11) 4184-1241*/
function maskPhone(cmp){
    var v = cmp.value;
    v = v.replace(/\D/g,"");
//    if(v.length > 8)
//    {   
//        v = v.substring(0,8);
//    }                 
    v=v.replace(/^(\d\d)(\d)/g,"($1) $2"); 
    cmp.value = v.replace(/(\d{4})(\d)/,"$1-$2");    
}

/*Fun��o que padroniza CPF*/
function maskCpf(cmp){
    var v = cmp.value;
    v=v.replace(/\D/g,"");                    
    if(v.length > 11)
    {   
        v = v.substring(0,11);
    }
    v=v.replace(/(\d{3})(\d)/,"$1.$2");      
    v=v.replace(/(\d{3})(\d)/,"$1.$2");
                                             
    cmp.value = v.replace(/(\d{3})(\d{1,2})$/,"$1-$2");
}

/*Fun��o que padroniza CEP*/
function maskCep(cmp){
    var v = cmp.value;
    v = v.replace(/\D/g,"");
    if(v.length > 8)
    {   
        v = v.substring(0,8);
    }
    v = v.replace(/^(\d{5})(\d)/,"$1-$2");
    cmp.value = v; 
}

/*Fun��o que padroniza CNPJ*/
function maskCnpj(cmp){
    var v = cmp.value;
    v=v.replace(/\D/g,""); 
    if(v.length > 14)
    {   
        v = v.substring(0,14);
    }                  
    v=v.replace(/^(\d{2})(\d)/,"$1.$2");     
    v=v.replace(/^(\d{2})\.(\d{3})(\d)/,"$1.$2.$3"); 
    v=v.replace(/\.(\d{3})(\d)/,".$1/$2");           
    cmp.value = v.replace(/(\d{4})(\d)/,"$1-$2");              
}

/*Fun��o que padroniza DATA*/
function maskDate(cmp){
    var v = cmp.value;
    v =v.replace(/\D/g,""); 
    if(v.length > 8)
    {   
        v = v.substring(0,8);
    }
    v=v.replace(/(\d{2})(\d)/,"$1/$2"); 
    cmp.value =v.replace(/(\d{2})(\d)/,"$1/$2"); 
}

/*Fun��o que padroniza DATA*/
function maskHour(cmp){
    var v = cmp.value;
    v = v.replace(/\D/g,"");
    if(v.length > 4)
    {   
        v = v.substring(0,4);
    } 
    cmp.value = v.replace(/(\d{2})(\d)/,"$1:$2");  
}

/*Fun��o que padroniza valor mon�tario*/
function maskMoney(cmp){
    var v = cmp.value;
    v = v.replace(/\D/g,"") //Remove tudo o que n�o � d�gito
    v=v.replace(/^([0-9]{3}\.?){3}-[0-9]{2}$/,"$1.$2");
    cmp.value = v.replace(/(\d)(\d{2})$/,"$1.$2"); //Coloca ponto antes dos 2 �ltimos digitos
}

function RequiredCheckRadioValidate(src, args) {
    var retorno = true;
    var abc = '';
    //var fieldId = src.id.substring(0, src.id.length - 2) + 'Value';
    var fieldId = src.id.substring(0, src.id.length - 3);
    var field = document.getElementById(fieldId);
    if (field) {
        if ((field.type == 'radio') || (field.type == 'checkbox')) {
            retorno = field.checked;
        }
    }
    args.IsValid = retorno;
}

function RequiredCheckBoxListValidate(src, args) {
    var retorno = false;
    var fieldId = src.id.substring(0, src.id.length - 3);
    if (document.getElementById(fieldId)) {
        var inputs = document.getElementById(fieldId).getElementsByTagName('input');

        for (i = 0; i < inputs.length; i++) {
            if (inputs[i].type == 'checkbox') {
                if (inputs[i].checked) {
                    retorno = true;
                    i = inputs.length;
                }
            }
        }
    }

    args.IsValid = retorno;
}

/*Fun��o que valida os campos de um formul�rio */
function ValidateForm(validationGroup)
{
    var isPageValid = true;
    
    if (typeof(Page_ClientValidate) == 'function') 
    {
        var isPageValid = Page_ClientValidate(validationGroup);
        if(!isPageValid)
        {
            for(var i = 0; i < Page_Validators.length; i++)
            {
                var cmp = Page_Validators[i];
                if(!cmp.isvalid)
                {
                    $('html, body').animate(
                        {
                            scrollTop: $("#"+cmp.id).offset().top - 25
                        }, 
                        500,
                        function(){
                            $('#'+cmp.controltovalidate).focus();    
                        }
                    );
                    break;    
                }    
            }
        }
    }
    Page_ValidationActive = false;
    return isPageValid;
}

function AjaxWS(method, params, isBlockPage, fn)
{
	if(util.url == '')	
	    util.setUrl(window.location.substring(window.location.lastIndexOf('/') + 1));
	
	util.params = params;
	util.callback(method, function (dados) {
	    if(fn)
			fn(dados);	
	});
}




