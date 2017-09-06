function contact() {
    var companyName = $("input[name=companyname]").val();
    var firstName= $("input[name=personfirstname]").val();
    var lastName = $("input[name=personlastname]").val();

    var model = {
        Organization__Name: companyName,
        Person__FirstName: firstName,
        Person__LastName: lastName
    };

    var zapierUrl = "https://hooks.zapier.com/hooks/catch/42016/r4df9p/";

    $.ajax({
        type: "POST",
        url: zapierUrl,
        data: model,
        dataType: "application/json"
    });
}