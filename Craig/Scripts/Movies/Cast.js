$(function() {
    function castMember() {
    }

    function castViewModel() {
        var self = this;

        self.castMembers = ko.observableArray([
            new castMember()
        ]);

        self.addCastMember = function() {
            self.castMembers.push(new castMember());
        }

        self.removeCastMember = function () {
            if (self.castMembers().length <= 1)
                return;

            self.castMembers.pop();
        }
    }

    ko.applyBindings(new castViewModel());
});