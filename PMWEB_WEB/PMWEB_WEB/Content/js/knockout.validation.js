﻿(function () {
    function o(a, b, c) { a.isValidating(!0); b.validator(a(), c.params || !0, function (e) { var d = !1, i = ""; if (a.__valid__() && (e.message ? (d = e.isValid, i = e.message) : d = e, !d)) a.error = ko.validation.formatMessage(i || c.message || b.message, c.params), a.__valid__(d); a.isValidating(!1) }) } if (void 0 === typeof ko) throw "Knockout is required, please ensure it is loaded before loading this validation plug-in"; var j = {
        registerExtenders: !0, messagesOnModified: !0, messageTemplate: null, insertMessages: !0, parseInputAttributes: !1,
        writeInputAttributes: !1, decorateElement: !1, errorClass: null, errorElementClass: "validationElement", errorMessageClass: "validationMessage", grouping: { deep: !1, observable: !0 }
    }, f = ko.utils.extend({}, j), k = ["required", "pattern", "min", "max", "step"], d, l = (new Date).getTime(), m = {}; d = {
        isArray: function (a) { return a.isArray || "[object Array]" === Object.prototype.toString.call(a) }, isObject: function (a) { return null !== a && "object" === typeof a }, values: function (a) { var b = [], c; for (c in a) a.hasOwnProperty(c) && b.push(a[c]); return b },
        getValue: function (a) { return "function" === typeof a ? a() : a }, hasAttribute: function (a, b) { return null !== a.getAttribute(b) }, isValidatable: function (a) { return a.rules && a.isValid && a.isModified }, insertAfter: function (a, b) { a.parentNode.insertBefore(b, a.nextSibling) }, newId: function () { return l += 1 }, getConfigOptions: function (a) { return d.contextFor(a) || f }, setDomData: function (a, b) { var c = a.__ko_validation__; c || (a.__ko_validation__ = c = d.newId()); m[c] = b }, getDomData: function (a) { a = a.__ko_validation__; return !a ? void 0 : m[a] },
        contextFor: function (a) { switch (a.nodeType) { case 1: case 8: var b = d.getDomData(a); if (b) return b; if (a.parentNode) return d.contextFor(a.parentNode) } }, isEmptyVal: function (a) { if (void 0 === a || null === a || "" === a) return !0 }
    }; var n = 0; ko.validation = {
        utils: d, init: function (a, b) {
            if (!(0 < n) || b) a = a || {}, a.errorElementClass = a.errorElementClass || a.errorClass || f.errorElementClass, a.errorMessageClass = a.errorMessageClass || a.errorClass || f.errorMessageClass, ko.utils.extend(f, a), f.registerExtenders && ko.validation.registerExtenders(),
            n = 1
        }, configure: function (a) { ko.validation.init(a) }, reset: function () { f = $.extend(f, j) }, group: function (a, b) {
            var b = ko.utils.extend(f.grouping, b), c = ko.observableArray([]), e = null, g = function h(a, e) { var g = [], f = ko.utils.unwrapObservable(a), e = void 0 !== e ? e : b.deep ? 1 : -1; ko.isObservable(a) && (a.isValid || a.extend({ validatable: !0 }), c.push(a)); f && (d.isArray(f) ? g = f : d.isObject(f) && (g = d.values(f))); 0 !== e && ko.utils.arrayForEach(g, function (a) { a && !a.nodeType && h(a, e + 1) }) }; b.observable ? (g(a), e = ko.computed(function () {
                var a =
                []; ko.utils.arrayForEach(c(), function (b) { b.isValid() || a.push(b.error) }); return a
            })) : e = function () { var b = []; c([]); g(a); ko.utils.arrayForEach(c(), function (a) { a.isValid() || b.push(a.error) }); return b }; e.showAllMessages = function (a) { a == void 0 && (a = true); e(); ko.utils.arrayForEach(c(), function (b) { b.isModified(a) }) }; a.errors = e; a.isValid = function () { return a.errors().length === 0 }; a.isAnyMessageShown = function () { var a = false; e(); ko.utils.arrayForEach(c(), function (b) { !b.isValid() && b.isModified() && (a = true) }); return a };
            return e
        }, formatMessage: function (a, b) { return a.replace(/\{0\}/gi, b) }, addRule: function (a, b) { a.extend({ validatable: !0 }); a.rules.push(b); return a }, addAnonymousRule: function (a, b) { var c = d.newId(); void 0 === b.message && (rulesObj.message = "Error"); ko.validation.rules[c] = b; ko.validation.addRule(a, { rule: c, params: b.params }) }, addExtender: function (a) {
            ko.extenders[a] = function (b, c) {
                return c.message || c.onlyIf ? ko.validation.addRule(b, { rule: a, message: c.message, params: d.isEmptyVal(c.params) ? !0 : c.params, condition: c.onlyIf }) :
                ko.validation.addRule(b, { rule: a, params: c })
            }
        }, registerExtenders: function () { if (f.registerExtenders) for (var a in ko.validation.rules) ko.validation.rules.hasOwnProperty(a) && (ko.extenders[a] || ko.validation.addExtender(a)) }, insertValidationMessage: function (a) { var b = document.createElement("SPAN"); b.className = d.getConfigOptions(a).errorMessageClass; d.insertAfter(a, b); return b }, parseInputValidationAttributes: function (a, b) {
            ko.utils.arrayForEach(k, function (c) {
                d.hasAttribute(a, c) && ko.validation.addRule(b(), {
                    rule: c,
                    params: a.getAttribute(c) || !0
                })
            })
        }, writeInputValidationAttributes: function (a, b) { var c = b(); if (c && c.rules) { var e = c.rules(); ko.utils.arrayForEach(k, function (b) { var c, d = ko.utils.arrayFirst(e, function (a) { return a.rule.toLowerCase() === b.toLowerCase() }); d && (c = d.params, "pattern" == d.rule && d.params instanceof RegExp && (c = d.params.source), a.setAttribute(b, c)) }); e = null } }
    }; ko.validation.rules = {}; ko.validation.rules.required = {
        validator: function (a, b) {
            var c = /^\s+|\s+$/g, e; if (void 0 === a || null === a) return !b; e = a; "string" ==
            typeof a && (e = a.replace(c, "")); return b && 0 < (e + "").length
        }, message: "برجاء ادخال قيمة "
    }; ko.validation.rules.min = { validator: function (a, b) { return d.isEmptyVal(a) || a >= b }, message: "يرجى ادخال قيمة أكبر أو يساوي {0}." }; ko.validation.rules.max = { validator: function (a, b) { return d.isEmptyVal(a) || a <= b }, message: "Please enter a value less than or equal to {0}." }; ko.validation.rules.minLength = { validator: function (a, b) { return d.isEmptyVal(a) || a.length >= b }, message: "يجب ان لا يقل عدد الارقام عن {0} رقم " };
    ko.validation.rules.maxLength = { validator: function (a, b) { return d.isEmptyVal(a) || a.length <= b }, message: "يجب ان لا يزيد عدد الارقام عن {0} رقم" }; ko.validation.rules.pattern = { validator: function (a, b) { return d.isEmptyVal(a) || null != a.match(b) }, message: "Please check this value." }; ko.validation.rules.step = { validator: function (a, b) { return d.isEmptyVal(a) || 0 === 100 * a % (100 * b) }, message: "The value must increment by {0}" }; ko.validation.rules.email = {
        validator: function (a, b) { return d.isEmptyVal(a) || b && /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(a) },
        message: "يرجى ادخال البريد الالكتروني بصيغة صحيحة"
    }; ko.validation.rules.date = { validator: function (a, b) { return d.isEmptyVal(a) || b && !/Invalid|NaN/.test(new Date(a)) }, message: "برجاء ادخال التاريخ بصيغة صحيحة" }; ko.validation.rules.dateISO = { validator: function (a, b) { return d.isEmptyVal(a) || b && /^\d{4}[\/-]\d{1,2}[\/-]\d{1,2}$/.test(a) }, message: "يرجى ادخال التاريخ بصيغة صحيحة" }; ko.validation.rules.number = { validator: function (a, b) { return d.isEmptyVal(a) || b && /^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?$/.test(a) }, message: "برجاء ادخال ارقام " };
    ko.validation.rules.digit = { validator: function (a, b) { return d.isEmptyVal(a) || b && /^\d+$/.test(a) }, message: "برجاء ادخال ارقام صحيحة " }; ko.validation.rules.phoneUS = { validator: function (a, b) { if ("string" !== typeof a) return !1; if (d.isEmptyVal(a)) return !0; a = a.replace(/\s+/g, ""); return b && 9 < a.length && a.match(/^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/) }, message: "يرجى ادخال رقم الهاتف بصيفة صحيحة" }; ko.validation.rules.equal = { validator: function (a, b) { return a === d.getValue(b) }, message: "القيمة يجب أن تساوي" };
    ko.validation.rules.trim = { validator: function (a, b) { return d.isEmptyVal(a) || b && $.trim(a) }, message: "يرجى التحقق من النص المدخل" };
    ko.validation.rules.notEqual = { validator: function (a, b) { return a !== d.getValue(b) }, message: "يرجى اختيار قيمة أخرى" }; ko.validation.rules.unique = { validator: function (a, b) { var c = d.getValue(b.collection), e = d.getValue(b.externalValue), g = 0; if (!a || !c) return !0; ko.utils.arrayFilter(ko.utils.unwrapObservable(c), function (c) { a === (b.valueAccessor ? b.valueAccessor(c) : c) && g++ }); return g < (void 0 !== e && a !== e ? 1 : 2) }, message: "يرجى التحقق من أن القيمة فريدة." }; ko.validation.registerExtenders(); ko.bindingHandlers.validationCore =
    {
        init: function (a, b) {
            var c = d.getConfigOptions(a); if (c.parseInputAttributes) { var e = function () { ko.validation.parseInputValidationAttributes(a, b) }; window.setImmediate ? window.setImmediate(e) : window.setTimeout(e, 0) } c.insertMessages && d.isValidatable(b()) && (e = ko.validation.insertValidationMessage(a), c.messageTemplate ? ko.renderTemplate(c.messageTemplate, { field: b() }, null, e, "replaceNode") : ko.applyBindingsToNode(e, { validationMessage: b() })); c.writeInputAttributes && d.isValidatable(b()) && ko.validation.writeInputValidationAttributes(a,
            b); c.decorateElement && d.isValidatable(b()) && ko.applyBindingsToNode(a, { validationElement: b() })
        }, update: function () { }
    }; var p = ko.bindingHandlers.value.init; ko.bindingHandlers.value.init = function (a, b, c, e, d) { p(a, b, c); return ko.bindingHandlers.validationCore.init(a, b, c, e, d) }; ko.bindingHandlers.validationMessage = {
        update: function (a, b) {
            var c = b(), e = d.getConfigOptions(a); ko.utils.unwrapObservable(c); var g = !1, f = !1; c.extend({ validatable: !0 }); g = c.isModified(); f = c.isValid(); ko.bindingHandlers.text.update(a, function () {
                return !e.messagesOnModified ||
                g ? f ? null : c.error : null
            }); ko.bindingHandlers.visible.update(a, function () { return g ? !f : !1 })
        }
    }; ko.bindingHandlers.validationElement = { update: function (a, b) { var c = b(), e = d.getConfigOptions(a); ko.utils.unwrapObservable(c); var g = !1, f = !1; c.extend({ validatable: !0 }); g = c.isModified(); f = c.isValid(); ko.bindingHandlers.css.update(a, function () { var a = {}, b = g ? !f : !1; e.decorateElement || (b = !1); a[e.errorElementClass] = b; return a }) } }; ko.bindingHandlers.validationOptions = {
        init: function (a, b) {
            var c = ko.utils.unwrapObservable(b());
            if (c) { var e = ko.utils.extend({}, f); ko.utils.extend(e, c); d.setDomData(a, e) }
        }
    }; ko.extenders.validation = function (a, b) { ko.utils.arrayForEach(d.isArray(b) ? b : [b], function (b) { ko.validation.addAnonymousRule(a, b) }); return a }; ko.extenders.validatable = function (a, b) {
        if (b && !d.isValidatable(a)) {
            a.error = null; a.rules = ko.observableArray(); a.isValidating = ko.observable(!1); a.__valid__ = ko.observable(!0); a.isModified = ko.observable(!1); var c = ko.computed(function () { a(); a.rules(); ko.validation.validateObservable(a); return !0 });
            a.isValid = ko.computed(function () { return a.__valid__() }); var e = a.subscribe(function () { a.isModified(!0) }); a._disposeValidation = function () { a.isValid.dispose(); a.rules.removeAll(); a.isModified._subscriptions.change = []; a.isValidating._subscriptions.change = []; a.__valid__._subscriptions.change = []; e.dispose(); c.dispose(); delete a.rules; delete a.error; delete a.isValid; delete a.isValidating; delete a.__valid__; delete a.isModified }
        } else !1 === b && d.isValidatable(a) && a._disposeValidation && a._disposeValidation();
        return a
    }; ko.validation.validateObservable = function (a) { for (var b = 0, c, e, d = a.rules(), f = d.length; b < f; b++) if (e = d[b], !e.condition || e.condition()) if (c = ko.validation.rules[e.rule], c.async || e.async) o(a, c, e); else { var h; h = a; c.validator(h(), void 0 === e.params ? !0 : e.params) ? h = !0 : (h.error = ko.validation.formatMessage(e.message || c.message, e.params), h.__valid__(!1), h = !1); if (!h) return !1 } a.error = null; a.__valid__(!0); return !0 }; ko.validatedObservable = function (a) {
        if (!ko.validation.utils.isObject(a)) return ko.observable(a).extend({ validatable: !0 });
        var b = ko.observable(a); b.errors = ko.validation.group(a); b.isValid = ko.computed(function () { return 0 === b.errors().length }); return b
    }; ko.validation.localize = function (a) { for (var b in a) ko.validation.rules.hasOwnProperty(b) && (ko.validation.rules[b].message = a[b]) }; ko.applyBindingsWithValidation = function (a, b, c) { var e = arguments.length, d, f; 2 < e ? (d = b, f = c) : 2 > e ? d = document.body : arguments[1].nodeType ? d = b : f = arguments[1]; ko.validation.init(); f && ko.validation.utils.setDomData(d, f); ko.applyBindings(a, b) }; var q = ko.applyBindings;
    ko.applyBindings = function (a, b) { ko.validation.init(); q(a, b) }

})();