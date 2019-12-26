using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Persistance.Migrations
{
    public partial class seedTagTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeTags_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeTags_Tags_TagId",
                table: "ExerciseTypeTags");

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("0b37dc97-9ffc-4a7e-9269-339b5bd3651f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("16797f2d-9afb-42f9-9b30-69084e80577e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("228a4692-b06a-4ac2-8608-5448a05cba72"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2b1460b4-edf4-46ac-91ef-aed394506be3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("46479c5b-616e-4d0a-852c-ca5358f9f40c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("51625d5b-63e1-4fe9-b3ba-f57067c751ae"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5e2e88e3-d845-4b30-bded-f382c2ec3ff7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("76899505-0a20-4581-88c7-a066a334566d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7a5dbced-c757-47ba-86b7-91b937733873"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("905f8b68-3adc-4840-ab3d-c9bfdf0cf7f2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9efb40f2-dec4-41b7-9456-c329e254996f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b0cb9792-b914-4c3f-96fd-eb1c48ce2763"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b2a30e8b-95dc-4416-be4e-80100a990d2e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("bec2e87b-34c1-475a-a81a-d74a622e079b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c0a67e7b-14ce-469d-b760-aae663a12f11"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c3424e20-04f0-4137-ab14-e03f8a1d3627"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c91db4e5-2909-4599-a263-c31274e69547"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d64a3082-1867-4221-9a2c-5ce7c83966a3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d80ab46e-c738-49d0-8116-08da0b9340c7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d9084bce-d342-4e37-8777-ecfb74bdc56d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0299d6af-89f4-4c54-956b-59aa61796fd7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0c6d4916-ca2a-4ba7-9425-533bd8d18569"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("39af0487-69b9-46c6-b2bf-682bff327c33"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("5ac43887-533f-4813-8cdc-e3bc061fc091"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("6baea34a-641e-42c6-a5ea-6402b2d248c5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f518afc-a67c-4a55-9d68-b709707eb949"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("a2400fec-dbfb-4ea2-a205-9b9f7e96b9be"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b2cd252d-d2e6-41e7-810a-906a11417d26"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("ce3915d8-0e3e-4b04-99b2-34eabc9232bc"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0c8a5182-ef12-47c6-af9d-381a11ff03ca"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("0ea0a473-abca-4d6f-b338-3805d31a96bd"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("2b5bcc30-8676-436a-b38a-341e6623e1c2"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("4f334f0f-b588-421c-a312-98b6db1fea58"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("6688dbb1-f2fa-4368-b050-9958b4d334d7"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("993bff72-f307-42c6-9127-89219b1f251b"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("b6178cdb-216b-43bd-a77a-821204668741"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("bbd1f8a0-ba0c-45df-b12f-ee91cf0ff8c0"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c2bbf800-8e8b-43f4-abcc-1fd1dabea2e8"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("c84ae76a-392f-465d-9076-04cf85f1a436"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("d2c7954e-9348-4208-ba1b-87950598f6ab"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f863aba1-ec6d-446b-8172-44d6f5b540ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("00216c4d-b74c-4a1f-922c-7ee6afade152"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0079888e-5d18-463f-a8d9-c04611fc8f92"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0198ed40-e9cc-441c-ad48-6c0022c9c789"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("01b7fa0d-7a15-4b18-82b9-e7748bdd8649"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0232637b-5e8c-4c12-a92a-26866c41f9ca"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("068a02c0-2a76-476e-b7e2-ba8042d05c77"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("06d53e38-0cd2-45b1-bfd9-aee36e28d62a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("081dc89e-c4af-4431-882a-18ffac33e1b5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("09dcf93b-464d-45b4-a7c3-a177e1f6f134"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a14b0ad-9fb2-488f-9748-4cb39421364f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a202261-0c4c-4147-ba6e-409226a53fa9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a69d4da-fd42-4b8b-a4bd-f2b4e52c40d6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a875ee2-5d26-4f38-a552-f3291678cd05"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0bd28f2b-bb3a-4d78-b912-51d9b16e6a95"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0c8ea577-fec7-459f-8d7a-cc61304fab9e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0cd36d67-4470-40c9-a386-589da36b9492"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0d7b796d-4b87-4376-b7da-55121331840f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0dfbf533-e37f-474f-8ddb-31541e4bb17d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0e822bfc-9337-4ead-af92-029bfa2bdcd3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0fdb38ea-2b4f-4beb-b1f4-c2e4016c79ca"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1126ba55-b7ee-4b80-b84d-861c6620d4e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("13072c50-7a79-4b56-82f4-b021e7cec04c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("16ffeaf8-b8f4-4a94-b4b2-7735abe3cb79"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("178c77dc-e783-4b89-afac-7b0835e9d140"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("17db6a19-3549-4e36-8334-38c390fb93a6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("18e69069-078c-402f-959e-c04f104827ee"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1a2a6804-7529-472c-95cc-96989bb34d5d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1a5afbdd-a941-48c8-acdb-53e24868f17b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1a7ff548-020f-4e06-9801-f90ab9bba2ea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1ad02957-7c32-4b24-a8d5-ba08a37ec2d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1b2d6c98-ce4f-4a52-9fdd-7bf7c44aef44"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1d4a491d-d5dd-4bb8-978c-a6338dec0bbe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1d5dfc4d-e8c1-4dde-a2b5-273ec1e5de88"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1eb35899-5c57-41c0-a0bf-e118b015e7fc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f0900b6-d6c5-4b06-bf09-35befb9c21c1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f0b7b8e-a534-4aed-946c-74149256ef8f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("209296ec-d07a-4600-9ff1-fd9b015220f7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("235cee46-fd12-4a04-813d-87e6d8bd4212"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("241aa99c-8085-4945-a2da-b37f41c6883f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("24b772d1-bcc1-4bb7-bb69-177dd2040461"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("24fa36fd-9e03-4368-be1d-080e9e679a5e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2746354a-0df5-4f8e-9c15-47a5be653974"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("284f6efb-a20d-4a57-8170-e9f0cf2676fd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("28ea5845-e73f-4fc0-b761-f36d6c9ffed3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("29450890-4e8e-4702-9e62-99db094dc7d4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("29faa54d-76d7-453f-a349-d52ee37e8927"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("29fb511e-d0c4-465d-9265-52ae824cf081"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3b2782-9270-4079-882c-c85157554a7c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2c2dfef9-446f-4ef9-99ef-ea1792ae7d68"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2da8cf3e-2dc0-446e-8e5b-8b3a1c166adf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3074305d-f001-4be2-ad67-90e7dd5669ed"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("31270d7b-1c02-424b-bd36-0926c786cf12"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("331ef8d6-42c7-48e8-8c32-128c3674d4b1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("338c1cf2-4bb5-44d0-94af-658e3b556422"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("339481f1-ebbd-437c-b74a-a1dcfd835eef"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("36c45f64-1d0a-4353-ad55-719f40cf8c0f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("371119cc-4e86-44c2-a3c0-478bd47a9ea1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("37847dc9-7925-4b63-969c-095eb855c4ec"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("386ba1c8-63c8-4080-bc67-21521d5def6f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("38a10ccc-63d4-4d96-a077-bfc8d0e16c21"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("39871f8b-c6f0-4680-9868-9bf1e0a352ba"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3abdaeed-d8fe-41e9-97d5-a77a71572f4e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3e45c5bb-0fd2-4513-aabc-8f5033d88178"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3e5ade45-5fc9-4b09-9d43-ab626b51eeaa"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3f3bd248-d49b-4b2e-8561-77665ea8f083"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("402888a2-8ccd-4144-8c8e-5c270cf3c744"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4041011c-840c-440f-a7f7-aca91c68c85c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("40ad67bb-0575-4471-99e6-52a35ee2e9c5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4107505a-8892-46e8-881c-3ed8d03d3436"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("422aa4a4-da48-4534-a6f9-5342bc8ed2d9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4404a4a5-e27e-4729-922b-8f79f624a053"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("44b3a671-2ce2-4c3f-9d47-d8f03a23eeb2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4672198e-7f6a-4040-b0b8-2aeae7839835"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("471f5d5d-a69b-4fbb-bb93-5ec7079cac77"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("476daad7-0bb3-4005-be72-65dc809f81c9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4814e529-eb2f-4460-a0bd-39d01ecc85be"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("490ccef1-ad72-4ada-ba30-434c4ecd6196"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("499995b7-cfd1-4649-812e-3d41f9d86cb2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4a136080-2e25-458f-a646-f2846eace1fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4a1b9e97-7b51-4059-97ae-a9d7237bfdc6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4c083d3a-4b18-477f-8b74-6eebb0923530"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4c0f5a85-e13a-4e04-a222-7a03e758c457"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4cf9c531-f972-4ce0-9f09-d5710731ca45"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4db58e89-1394-46a6-8cc5-48251cebea12"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4fb30e6f-01b1-4a09-947b-ba02992d1186"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4fd9bed8-790d-48f0-8473-5d233340ecaf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("53c6cacd-f5ba-4c92-a89e-1d7fb63f6cea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5490db04-9a45-4df4-8da3-ee7a98c2fd8f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5626439e-8f52-45f5-8ab1-651568732ad9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5794e1cf-0278-4eb4-8b70-14e500b55815"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58ccd522-8a23-4d5a-8912-2ccccaab29f6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58dd3f9b-9f74-472f-a8ae-2c1cd1718cce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("59b85371-3bbe-46eb-8305-598eb53b365a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5c498a7f-6c0a-4b0d-8a78-d27062ccf7ae"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5e2e8537-d4e3-4be9-b363-fb15adcbe149"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5ec1d5cc-5520-40cb-aae2-329309746c44"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5f2be98e-fbf9-4f46-b0f8-52b2a14bacd1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("608f47dd-b38e-4f86-b1b9-a48e4abc6ce9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("614b3ead-19ff-4e89-a812-87b29a92e331"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("617f0399-06f5-461e-8f8d-86bd6f4eeed2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("62cca739-62c4-43e8-b6df-b37cdd70ec02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("643a3dc8-53f5-4fe4-8eff-9657f917b4bc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6505d57b-3e91-462d-83ad-598764fd10c5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("66d68f8b-3501-4cee-9630-c28e08b84037"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("67b87b0c-7ff6-4537-af9b-9ffb630fb1e2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("67bbcb4d-a7c0-4669-947e-59c5413202ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("67f501d4-b2d2-41cf-b2b6-e9238d5651c6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6867424c-9f23-4e59-a017-b3a2fe98e113"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("68b020c3-ae0a-45f0-9a84-60e00a216f3b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6a1891c3-4073-45b8-9768-4c213f0b6b70"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6c6b7008-9327-49c3-b6ea-fa72302efe1b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6decf93c-b3d3-4a9a-834f-53f26a27848d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6f0a711b-4a00-48d3-b6a7-3fc955e0b05a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6f0ef29d-7bcf-4717-b5a6-401a18126557"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("71e98490-0dae-429e-9a4b-c9d64f1138ce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("74e0c60f-7f67-4c91-804d-668cfad6ca82"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("74f029c4-4e2e-43f1-9788-84dfe1d6ecea"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("75c26836-3897-4bef-a74a-5a5c1c787aaf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("776fc5e8-a970-4b3e-ae4f-581db167ecf9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("782ed4e8-7e76-4b0e-85c3-21e68c9cbb6d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("78540b88-7bfa-499d-82d9-4d5fdaaebffb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("78652e1e-7e9d-4757-a5c3-f14f49cfa622"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("791f737b-f570-45fb-94c5-8e22861d9b2b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79c0ac3c-607f-4a91-aa82-025f6d1d7450"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7a26ff79-98d7-4799-923d-f858fb911578"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7a94e399-dd5a-4813-8e2f-25d83089b8f0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7b4611e7-b47d-41f0-8faa-620e1552e75f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7b67b26e-53d3-4741-a3a8-4875b84b26b6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7b775cb2-4de8-46ca-b031-77c9756893c2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7c0dff0f-8d1d-4621-be67-6e07f183594e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7c923bd5-f100-48fe-a8a6-116994f622c3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7ccf0ba0-232e-41a9-acb3-0d3a59bf1879"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7da52905-91ab-4ea2-8bb6-73b6601b8d02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7daf9d0a-da1e-4763-bcfd-eb83cdaef700"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7e1b7fb9-9f46-415a-b482-f661688e7659"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7fa8007e-498b-40e3-ae41-ed94f6d9f81e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7ff2e826-b4d4-4fa4-82ea-05c82f62488c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("804bd6d6-3e2b-46e5-a9d1-2637ee367b2a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("82a4cf88-033b-4d64-9234-131fcc8c0cd7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("82b9377f-5a87-4a32-b264-986b61e8d292"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84fb19ce-7c41-4d32-a150-505d97241d2b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("85143ad1-40f0-41ba-b274-f01a7eaf6c04"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("86304bf9-ad46-49c1-b172-f1f983c6cdd8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("869eb287-d280-4496-a2b0-034c79740de1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("875d90b1-43d7-498c-9741-2339c6fa236c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("87e80e3a-7911-4576-b512-45611fd9ad51"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("892dae4f-bcb0-4140-b70a-d7d9ec78269e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("897e584d-86fa-442d-9fa9-3a5cdf7a25c7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("89a0ebc5-8e71-4ea4-a3f9-4822f7811c76"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("89ced772-f3a2-4c99-95ba-79b8de067858"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8b336e4a-fc45-4f76-91ad-125f908f7d00"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8bedcad8-826e-4970-a4ec-8a0b3b55f6e6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8c830a54-4f64-49ca-bd82-a6f0fea60ee2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8d76712a-33c4-4646-afff-470d93864640"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8dc5c2ab-4d34-4ef6-8351-ffdf61d2b992"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8ec5d9b1-2571-422e-aea6-3d05d5795ed9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("90fbcf3d-9628-41dc-8850-9dceb4bd3956"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("91474780-b641-43fb-b342-90dd5f19f282"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("916b0fa6-658a-43c7-8fdf-6c5634bd68f0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("92325b2b-112a-4318-9e92-4864343c299e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("926ba3b7-4eb0-468e-9ce5-fdf411b5ba53"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("945733a8-c533-46b5-b148-81f67ad683cb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("969e83fe-7edd-493c-a1dc-fdd21314dbcd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9731257e-ff4b-45f2-a317-0bb30af2e0da"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("97399693-2e64-4714-a907-c13b2c9f9fa4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("97e331a8-1e12-4a96-8b89-2d8c08717d3f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9994e349-3cba-440d-b951-6fbe9dad9b1a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9a62bab9-9ae7-4948-8a74-83383d0ea6a3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9af2cc90-3b74-4532-b06c-03a7df9f469c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9ba57a80-a63e-488d-a66a-c48b0587969a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9d88d02e-917e-4e38-afa9-f6c2b0005ead"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9ddbc8bd-abcc-41fb-844c-db019ff97bbb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9e13388e-7811-48d5-b122-9d514782f99b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9e59970e-8e97-4abe-81c2-04c0dfde6026"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a05f6e09-4ce3-4afd-beb0-a6b4e5a8c67c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a12a3379-b4ed-4584-a2ce-328c2da9501d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a2d4f135-b084-4585-93c8-9e36fbd3b8c2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a2fed809-b4a8-4a37-8e89-c81e046f0d92"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a357b8a4-fbb4-4a47-94e2-266477b6f32e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a42c7519-d2cc-4ba4-b11b-a5c8301d1226"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a5210d13-cdd7-4e37-9e2c-2994f4b8a7fd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a75687b7-4f50-4a85-9598-bc45ca3b10ad"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a878228d-1daf-4f3d-9bda-ece021ea8a52"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aa39a679-bf39-45c1-be60-422b302e5995"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ab3a7d64-443f-4fb4-9aa9-d33ee8f1b1f0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("abb06c4f-3123-4f05-a5ab-83b7fd88a199"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("adf6a5ab-27d2-41f8-9f56-04d6a5e1eab1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("afefa825-d026-49b3-bc3f-8e5c0a08abd2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b0022c79-9fd3-4181-b07e-7ef233f9b304"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b02e9eaa-eee0-4c32-81b2-21d525c94861"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b0346789-a6b6-478a-a48c-7459dd93a6c2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b06cba8f-97bd-4efc-9855-014a6d44e8b6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b0d028c3-8317-45b3-8a58-b6a1eea55bf5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b263fc37-2982-4522-ba51-e6420b827309"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b4557043-2ae6-4276-b949-f8a6a51c284d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b55b85cb-f375-467a-b607-a9657a04f7bd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b566e55a-cce8-4d99-a68a-6b0ae913f85d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b6c8aab0-471b-4bc9-a1a5-23dffe441989"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b6e402ca-1cc5-4f24-842b-a103aa5f8a19"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b846a4c4-e3f5-4aa1-8d15-0fafce211022"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b9978a15-a9fc-4b30-ae6e-a3caa6ed50e0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ba23d332-0f60-48c9-912c-f53fe11505b1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bbe9e6f7-0caa-4d2a-b559-d562bdd7c728"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bd46bbf2-e847-413a-9eb2-3f4d6d5f3469"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bd495739-7207-455a-a262-7bf341474c6f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bfe07165-f6b2-4d50-94a4-92befb925f38"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bfed7ea3-8065-4b91-bd95-95a535cccdce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c033612e-8222-47cb-a244-9fb05bce2e5c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1d0a3bb-4095-4ffd-a2b0-fa3d5c1edb52"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c325152f-fa03-40e5-a495-52d2ddda9160"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c4c1a83b-595d-4bd1-ae69-701a4f202dcf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c53d3603-6238-4f12-a766-cb5fb05670e5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c8603ad6-3940-443d-b37c-fe941592ba5f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c9a30de0-a068-4d19-bc9a-e5e7e9350261"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cb6dd9f3-8ddc-4682-9935-8696b6f3926a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cea4c943-7004-4152-9d38-c5abbeb6708d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf43eb14-4de6-4d0a-9ece-6b5fce2331f5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf9a18ba-c763-40b7-b918-a05dd4b578fc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d07d073b-4d77-4ca6-b58f-ca585aa1062f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d1afd325-b50c-4125-a77e-8d54bd470813"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d3e386fd-2536-4a53-82c5-26cc8daac3d8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d5117871-e694-4e39-9f33-73f69339eded"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d5193c0a-fcda-43ca-9b3a-79302b2d4fe4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d519b6e6-604a-47e2-8535-422c31ca4830"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d5e60d05-298f-432d-a6f3-11f99cdb4bdd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d65d4440-afe7-44bc-8e0b-d4ec699fcc6f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d66baaf3-1264-46e3-b191-d2d5bf986489"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d6852186-cba9-4357-ac26-bc7dd0ba1eba"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d74bc6c6-7bb1-42c3-a21a-5ef59ac3dc57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d7ac0e18-c114-496f-a8cc-d557b8dd6fd7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d7d2e2e4-1f8b-4981-a97f-456633b8bcc5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d91643ef-ea82-4316-8cd0-e8b2c7b3299f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d91d4f58-9ee9-4d19-83b4-c93e69f12d7b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d951996b-f520-4b1a-9ae7-acaee59cc1b5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("da446a71-2263-4ce5-af72-e90a4c0bb99c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("da5a6c66-7781-4dba-b13e-1662b77d7ec3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc5d296e-64da-4ab8-83e2-ad422f078b77"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6ef99a-72be-49f6-b592-657717380fbe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dce5cd77-b2c1-4fc3-9fc8-1b3ab7ff7622"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dd7c94d3-8979-4c63-b4a3-8bc729ba01ec"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e4f15bd2-95dc-41a8-8a48-196ea2a633bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e568667c-c324-4aa6-b65e-67d1a2ea45d5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e6c1ea62-32cd-465d-ac06-adfdb05d5e3c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e7efb385-4303-428f-a97d-59ec22a79459"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e8656a94-3128-4a79-8c8d-b4a1b9e7ec57"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ead0f417-c5d8-47ac-b97e-578199388f95"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eaea3a53-0196-45e7-87b5-0d4224d8e036"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eb90cd28-9fb4-464d-ba20-18c3ee744377"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ec54d4c4-08ff-48de-9025-f9c061634e87"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ec836f7a-bd15-4f22-8c2d-6673297983f4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ed00969f-9e1f-4b24-b277-df9dd9c633c3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("edc03336-5eb2-46b7-8f65-01f68fa7e30e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ee2b6a47-4224-4db9-80d9-65de2f9efee7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eeb26208-69f3-43b9-b179-b17e6a03d9d2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f0124f80-8f3c-499f-a921-78d0d03e861e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f153ef29-b4ee-49a9-8558-7a9f78db97c2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f3fd97af-7774-4626-bce0-a92799dff4a2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f5a5763c-1e7d-43da-b95c-10cb4a8c0392"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f65b8cc0-2854-45b4-a8d4-d1abc91e0cb9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f6bb130d-5311-4d50-8d7a-034c423a69a6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f734fabd-3fb3-4972-8bf5-bf7d15c1e45d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f7dfe1f0-3a9b-45d5-adfd-f5c51680450f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f919abcf-9675-4139-9aba-c56e1cb6b54c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fb481a14-4dba-42ea-a0cf-eb43c049d965"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fbc8342d-74e3-4747-a5dd-77e7ff979321"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fbd8f29c-9c8e-42a5-989f-14517a3ea8e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fc3d15ff-a663-44cb-bfb6-9be7625934a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fcafbe1e-270e-4240-bb42-14da8a165d55"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fcb50de6-5b3c-40e2-b62f-4d976ae66416"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fd2e0d8f-978c-4840-8a55-a36dcd0cc046"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fd73cca8-8fb3-4606-a96e-aed3015ad159"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fd9aa862-8a09-45ee-9e74-fb6ff59bb9de"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fdbb5fed-e517-4b93-ac56-c87327f373d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ff36be75-61b2-4688-8a6e-e77864378c02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ffd5ed3b-4fbb-47e8-9a7c-61c7d5b1e113"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("c0786318-d7e4-4965-8788-0126104224a0"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c516caf8-d319-4f10-820d-93cce49a1b1f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d56051cb-4751-4a11-b72e-e762e42fc762"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("2141d935-3b9c-4734-abb8-3ede32752166"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("4c699b31-6665-4a2d-bd0c-220365664b09"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7") });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId" },
                values: new object[] { new Guid("43586d3d-51d9-4e88-9633-d04e197db885"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("75b266ed-024d-4bc5-a5f0-5f5d1a1bd455"), "TrainingCreated", new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("49620b75-ee76-495e-83d0-f3c689e51571"), "NoteAdded", new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("60fcd88c-12c7-49e2-9981-bfed933860ae"), "MediaAdded", new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("8e322a22-1a36-4387-9393-c8fb90ac0c7c"), "TrainingCreated", new Guid("2141d935-3b9c-4734-abb8-3ede32752166") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("a311bfef-7477-49ec-97ff-7eef1fca06f5"), "NoteAdded", new Guid("2141d935-3b9c-4734-abb8-3ede32752166") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("42007cda-854f-4b13-9b6c-481053539ece"), "MediaAdded", new Guid("2141d935-3b9c-4734-abb8-3ede32752166") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("f8aa736c-c23b-4873-9e2b-33c5a197b691"), "TrainingCreated", new Guid("4c699b31-6665-4a2d-bd0c-220365664b09") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("46f3282f-1a33-4cd9-baf6-c6fa28a4fa12"), "NoteAdded", new Guid("4c699b31-6665-4a2d-bd0c-220365664b09") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("61cc5893-e466-4076-866e-b2f471df6948"), "MediaAdded", new Guid("4c699b31-6665-4a2d-bd0c-220365664b09") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("5cf9ffb9-9b2a-4f91-b8ae-e771dad7e965"), "TrainingCreated", new Guid("43586d3d-51d9-4e88-9633-d04e197db885") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("e181d0b0-1b67-4d1e-b679-63b8f74fd89d"), "NoteAdded", new Guid("43586d3d-51d9-4e88-9633-d04e197db885") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("59ff97e1-bacb-4d49-b48e-84e65ac4c2ab"), "MediaAdded", new Guid("43586d3d-51d9-4e88-9633-d04e197db885") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), "Admin", "https://ui-avatars.com/api/?name=Admin+&rounded=True&background=8FF25C&color=ffffff&", new DateTime(2019, 11, 14, 14, 18, 9, 928, DateTimeKind.Utc).AddTicks(1738), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), "Coach", "https://ui-avatars.com/api/?name=Coach+&rounded=True&background=99D064&color=ffffff&", new DateTime(2019, 11, 14, 14, 18, 9, 928, DateTimeKind.Utc).AddTicks(7661), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("4c699b31-6665-4a2d-bd0c-220365664b09"), "coach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), "SoloAthlete", "https://ui-avatars.com/api/?name=Solo+Athlete&rounded=True&background=27612E&color=ffffff&", new DateTime(2019, 11, 14, 14, 18, 9, 928, DateTimeKind.Utc).AddTicks(6169), null, "solo.athlete@trainingcompanion.com", "Solo", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("43586d3d-51d9-4e88-9633-d04e197db885"), "soloathlete" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("8c922905-6966-4529-9eeb-a25185e99503"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"), new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), "Athlete", "https://ui-avatars.com/api/?name=Athlete+&rounded=True&background=A6165A&color=ffffff&", new DateTime(2019, 11, 14, 14, 18, 9, 928, DateTimeKind.Utc).AddTicks(5520), null, "athlete@trainingcompanion.com", "Athlete", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("2141d935-3b9c-4734-abb8-3ede32752166"), "athlete", new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7") });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26"), 0, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e2f1d724-4d7c-4334-85fa-af5c07174012"), 0, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("14e9aed5-fd05-49d9-9210-5b0cf7b875fc"), 2, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("60bdf5d0-7ec3-4bf9-88dd-d7c90a2534c4"), 3, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7cf1538-21e2-4ea8-b231-e194be636f83"), 4, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b45bb1c4-67a2-4a54-a3ac-5ab478ef9389"), 5, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5f57771-c53c-4e2c-a8e7-21ac9a8d6230"), 6, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4e2fc2e-bd22-43fa-926f-5d96969fbc46"), 0, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("15c7b8d9-734d-4058-b784-5595d8e6b9ed"), 1, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("324681c5-f3f0-4b74-b24a-e01dccff8003"), 2, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d850321-6674-448a-93e4-c01ba27852c4"), 3, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("442a95d3-2908-4049-9f88-4cb78817ff4b"), 4, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8547c341-42ba-4768-80b3-9957063eda5e"), 1, new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7a20e5c-e71f-431a-9815-e5249aef3828"), 6, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ba0c5e31-4d50-4d9b-a240-f383aef07835"), 5, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f1f2e8c6-79d2-424c-8fd3-bab86b4be089"), 4, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e63d37f3-b1f5-47ff-baa0-4c5000536934"), 11, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c69d672c-2b09-4d49-9263-b6399f961390"), 12, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b98a27f5-0de8-4676-94ef-65d1399b622e"), 0, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1be1fc23-680b-4a1f-a15c-396b3a67b3f0"), 1, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c1a18a65-f92f-4106-80c5-a7b049f9d992"), 2, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("433ba5eb-0d3f-40e1-bf38-6cfae51e7021"), 3, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f2ea1a2a-9f38-4bde-9612-5a9c8801dffb"), 4, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c9e48370-1613-470b-9be9-c55f8fb86d50"), 5, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9b026adb-09e2-42ba-a9cc-9fb135627ace"), 6, new Guid("ad750baa-e2a4-442a-a521-447a8018b739"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("34d5fa7e-57f8-476f-b5fc-38f772138351"), 0, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f74249d0-4a53-4fb9-a1c7-15cd644d135a"), 1, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36c05f14-932c-4537-b566-1d3449e038dd"), 5, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("adb8f12c-17a5-4ec1-a7e2-7154ee82038a"), 2, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f23d9d04-a5b1-4aa2-b1cb-6c86e556dbcb"), 4, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a83f2f85-8d54-48b0-bd72-da69cd475dd8"), 5, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78016f37-f2d1-4c6c-8231-c123611f0cac"), 6, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("60253084-ca72-442a-9e72-ccd3de0ef9d7"), 7, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6717ff52-b7f8-48f3-b2d3-e5e52930930a"), 8, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("63587a3f-82d2-478d-a713-4e292d8d3619"), 9, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("395226fa-317d-416d-b756-c241f221c0f3"), 10, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7cbe9127-4dbf-480b-9918-1497dffbeb38"), 0, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5f48bb5e-2b43-4f44-8204-5349bc7b7712"), 1, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78270e2b-2670-4b4a-a2fb-f77566a1be51"), 2, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("913c60dd-0f86-4650-a699-2b06663658f3"), 3, new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("69e447ec-6b14-4dc7-aab3-f6fcf3a482f5"), 3, new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("215d80ce-f2c6-4f7e-b29b-ff6be34c2612"), 6, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b1bbb8a-d32c-44bd-9d7d-75813bfd3a83"), 7, new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("999175a7-9ac3-4702-8179-08beb430753f"), 0, new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89933abc-76a5-427c-92ae-b4a09ba8cf32"), 12, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5059acea-9513-46c3-8e49-71a23d2eec72"), 0, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58eae981-cb7b-4479-ac68-fbfb6eef70d0"), 1, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("46a93b97-eb4e-48bb-8eda-8a779d94bb66"), 2, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0dfef486-7b13-4e30-becf-91a17d95943d"), 3, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b40616be-33d8-4436-99ef-594711e81194"), 4, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0abec136-5b04-4dd7-a0b1-c8f6e1420eaa"), 5, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c323c699-e60e-4630-b28c-a67c9329642d"), 6, new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e1dbfcc3-3e9f-43b1-91c7-96a7543e1162"), 0, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4434eb5-cf47-4a88-8969-835485b863e5"), 1, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5ccc936b-b803-48cc-a216-f3ab25d0aa06"), 2, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f1a04e7-ec45-48f4-b79e-6f1ee9e12e76"), 11, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("34ea6cae-1f9e-4f42-bb43-64751ed81a48"), 3, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1e2f10fa-6ecf-4a39-bfd4-5ed13c0bb9db"), 5, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a90c283-f8b2-414e-aa30-d9885c814a1a"), 6, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4505ddfe-0736-4489-a7e9-0aff20f72e67"), 7, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0c3f81e3-7258-42c8-a8a4-9b650f9c69a8"), 8, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("acc341e8-d2a7-4080-926d-c852b250544d"), 9, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8ecf87e1-424e-49e1-99e7-d429b3667a99"), 10, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84a8d235-11a6-4c5e-9e5f-d08a824b7350"), 0, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e927a5f4-d6bc-4169-9ce2-6de307210c30"), 1, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e268aeea-21b4-4114-a086-96e4c78de026"), 2, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ca435e46-fa52-4f54-815f-fa263800dbcd"), 3, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b24b575b-d4f3-433d-8e6d-9b2bef823346"), 4, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e04b0e68-1b07-4a99-aac5-04bb5be0c02d"), 4, new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("66c9cf24-fe30-4662-a833-f8c05310c6f3"), 10, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a530335b-b9a1-457c-bd33-1589c2a64ac8"), 10, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bdc3f1c2-6a7d-4444-b538-e711c30a4369"), 8, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5cc64b12-3f10-4d96-b53c-fe8db4c4a876"), 1, new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a555cea3-a83e-422d-9634-9e5fe7aefd3a"), 2, new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4f65dbf-1416-405a-b734-88c3b3c2c147"), 3, new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f5d6c27-bce4-4b77-84ac-48d42895c0a2"), 0, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3bae668c-74da-4dcd-a550-c56951455347"), 1, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2701eb85-c334-4bf6-8b1e-a3a947ebf6f2"), 2, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bf72a61f-80d5-4800-84f5-22472f9de4c7"), 3, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9abb7931-7f0c-4af8-8692-d1e3df2167b9"), 4, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f8dfad82-1b75-4d8a-8709-49c8dffef3da"), 5, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4393faae-74d9-4a19-b139-68dbde3c0631"), 6, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fec24f70-3429-4294-b8b8-58732f19afbc"), 7, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e446ac85-b5b5-4069-849b-2bb4c98b8372"), 9, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("733a45bd-09d8-4e3a-ba1a-a7709697972c"), 7, new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1bfed914-8f54-4fde-8a31-fc0b3a6dae9a"), 1, new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a646bffd-4f64-44ac-ae11-795595fee461"), 2, new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("918193c4-d1ed-4333-b734-cebd44b120fb"), 3, new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92ffd2c2-c19d-446a-9fda-9e4ee38591d3"), 0, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6a9719fe-eaa3-4379-a0a9-a28908954fdf"), 1, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9de05a0e-f722-407a-8f43-13b7005c37fb"), 2, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("72d02287-eb3e-499a-9b69-1108ecee1069"), 3, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f9ca66da-ad1c-4fc7-a5d3-82b708ee9ad1"), 4, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("08260c23-382c-415f-b6a0-6a66c52b5d63"), 5, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf5f28f1-394f-4235-bd5b-eb10176a9333"), 6, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2f9f0b0f-0033-4ff0-a68a-4913db750caa"), 7, new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fc22feaf-4cac-424b-838d-f5ffe8ebb165"), 0, new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82d0d728-d5cd-4279-938d-fc1d1e760b64"), 9, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6926860-f4a8-4c2f-b2e0-58cecc91cd5b"), 8, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("77882298-5d2d-498f-b1ff-2440dabadac3"), 7, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4953e86e-0b3b-4c4e-b854-7875bdad3b2c"), 1, new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eeec4ded-e242-4414-bba6-24d803eebb69"), 2, new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("00e4951a-a557-4100-a664-d2fe5fd8fa41"), 3, new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b48f4433-bae8-468a-adc1-0e443f0f64e3"), 0, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f542d33f-d309-4104-ba30-ec367154ea86"), 1, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2df5ba55-60cd-4292-8860-f4d23a5bec73"), 2, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0ba92e39-a69c-4990-82a5-442adb6ef5c3"), 3, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d81a9249-f52e-4161-90c4-af023d839ea5"), 4, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("69842641-98df-42e0-affe-516647009921"), 5, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84b7f3e5-8508-424d-8b38-5e3548ccb82a"), 6, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("02acf8c8-51ec-465e-a3eb-d0a961e9038f"), 7, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("51bb3144-fd37-40af-adb5-707bccdccb47"), 0, new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("384759ed-ac70-4d70-bbc2-4bdf20988270"), 8, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("77db74b0-ec79-449f-b6b5-ccc944d095bc"), 10, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8824207a-130f-45e6-959d-985e3cb930a7"), 11, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("96ea5e50-5f15-49ef-b9d3-c9e56601b49c"), 12, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a3a0266a-9081-45a6-9345-85a9d5a2b0df"), 0, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2c95439e-83e0-4f6f-833a-18a4dc978190"), 1, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c43ded62-68fd-4337-8a0b-2cd4bc3e9e3a"), 2, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2db1af96-e104-412e-8bb0-2fe76c0fea29"), 3, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d3c08db5-3d17-45fe-978b-69b67be5106c"), 4, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9efa99a5-53b3-4915-a455-fcc2ebde5fdc"), 5, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2c2c478a-0b0e-4bd7-83a8-3ee9116b7e63"), 6, new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a0906b97-a00f-44b0-8c11-da51222ee50a"), 0, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e9ad192-694a-47bd-ac0d-c73fdf25701a"), 9, new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e04e401-d7c1-4dd5-9621-9a4236a75901"), 1, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d"), 7, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4f343a53-668c-47e1-a5cb-aff361c0c496"), 6, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f4c991f-7cd2-4c59-b58c-e748d4a77e7b"), 1, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("140b54b9-cc37-4071-ba5b-58da06c8548e"), 2, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4e2c95ff-192c-4388-8a6f-cff9b1cd0ded"), 3, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("83519c42-828f-48cd-b7dc-930318182164"), 4, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("abe4cd55-70f0-4d59-aa93-4e1504cbf2ce"), 5, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8db54080-2642-46a0-938f-eedf11ec3f6d"), 6, new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("96d3d992-8868-42d3-9bac-2b94589f58bf"), 0, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7834624c-5399-4275-86ba-4048c1cf343f"), 1, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c59e9707-ba51-471d-afa1-986506028b92"), 2, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("10ddac69-7943-4090-afea-a7eea423608a"), 3, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("222dd73b-f392-499a-8c6c-cd5ba6155c7f"), 4, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3ee45a20-a9ad-4781-82ed-bd099087f80b"), 7, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f67893c-337a-4c9b-845e-5ffdce460b61"), 5, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b1790ff1-297b-4342-b7bb-f870eefb054b"), 7, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ca430845-2e72-46c1-8cc0-9d968f31ba61"), 0, new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("54e685c5-9285-4446-8f42-f88ae581d30a"), 1, new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82ada276-374e-4be0-9a62-56090872b554"), 2, new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b7df519d-8447-4826-a56f-f5f3b1726510"), 3, new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2d9e9db2-e2a3-4eb7-aa93-bf639b657dd1"), 0, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("017e560b-3716-4468-b4cc-e2c61ee4d057"), 1, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("40f8dd46-71b7-46c3-94bb-526808a5e67f"), 2, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4ef96a0a-97b1-451f-9793-90c072ba1e85"), 3, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8df122d1-9b65-4419-bde9-ba2101f65962"), 4, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("471d4efd-5ff8-4ac1-8470-c215ba468f69"), 5, new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("851e6458-b3d9-447b-9d88-1b1cf11a6021"), 6, new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("06ca0aa5-1731-4ca1-b913-96bf3fca1b61"), 5, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7df2fdf8-4da9-49aa-9164-0b1376e69d80"), 2, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6d37e54f-994d-4c61-9ca2-5562334ba749"), 4, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7d99213a-2f19-42dd-a9b6-780ff25bd369"), 0, new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("47393843-df95-4838-bbe9-c5c26d4d5d2b"), 1, new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("113efa6a-616c-4aad-9a6a-09762a644a61"), 2, new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dde3c86f-2428-42f1-9a4b-d0eb6ae78935"), 3, new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f9dcd52b-d111-4ef9-9a3e-eb5a553cf355"), 0, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9f425b62-430b-4c56-be71-506885efd7ca"), 1, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("580bf4dd-bfce-4112-8fb2-1f6f18426e05"), 2, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f4d43f80-da84-4753-ba1c-47047bfa89ec"), 3, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("053a124c-5779-476e-9228-d7fafbbc95d2"), 4, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a7423d01-bd34-4f5d-9f28-46fccfc1cfc5"), 5, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1cc37bad-1efb-450b-85f2-d39286c1bcb1"), 6, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f84250cb-5fce-4b01-b21d-82512e9a1a7e"), 7, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("af10ed1d-8685-421f-b048-85d3c699343c"), 7, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6ed9fe43-1863-412c-b913-1062a4bad3c0"), 0, new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("036889ff-673c-475d-8391-13aa665166af"), 1, new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8f85c20b-a44d-4a40-9696-c8d43746c48c"), 2, new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6b8912d8-7db0-4042-aef9-8d8c3c99d25b"), 3, new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bb342297-f881-44f5-aea8-658f59cb92ba"), 0, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fe8ddef1-1579-4db2-ae80-ece4539a3578"), 1, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e88bb0a-508c-49b8-b217-afeb466e5b0c"), 2, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("46290264-fb2d-4577-8a17-b7ecfb24d1d0"), 3, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("75f0b405-0fea-4490-b352-a4d2bdf40857"), 4, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("196dce35-5cd0-49d3-bebb-a46649d1fffc"), 5, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a8d069ae-d975-4ae8-9b7b-4bea544194f2"), 6, new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4487e2b7-a373-483a-95e6-e51efe4fe786"), 7, new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("313e639b-4f06-4986-8396-eae2ba6051e7"), 3, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b863e74b-b17b-4b52-a907-de563cc053d1"), 6, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6731ea3c-c92d-4fe3-acc7-ac340bfeebaf"), 4, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b76acc7-49e1-40b0-b238-3351a776d295"), 5, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8bf8b971-4242-494a-af76-7c4335da5dce"), 6, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("22a3311b-bb06-4894-87fa-bc557bdae238"), 7, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("898b54cb-157e-4e4c-9eef-de905af16a1a"), 8, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf1a1c83-de64-452c-99aa-ceff0492af73"), 9, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d82e1c77-2bb5-48ce-92c4-499b5117fb2f"), 10, new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1e333570-172c-454c-973d-bfb0fcc6d7f2"), 0, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f4ccf2e6-bbc1-48a2-98fe-d791e31fb791"), 1, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58195b49-8112-4ea8-b29b-6046a3e00a05"), 2, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("27aa0552-d55e-4618-8fb3-9154776bf5fb"), 3, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("83af7320-0dcc-45bc-a02e-87a64f33bf79"), 4, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("baf709bf-6fd4-4752-bf21-806a55a47d1d"), 5, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2e388482-6ecf-4c02-9267-c0e5da6f14eb"), 5, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("43f9a46f-14b5-4943-9a9d-415ace8e2a5a"), 0, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("550b2027-e428-4712-8032-8f0c8e492d3a"), 1, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a8c4848-3ff6-4b66-8bbf-ed05301e5353"), 2, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("19bb9692-7049-4f5b-87b6-08fc37ffddb7"), 3, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("46f929e4-ca70-4171-a780-87826c61f54b"), 4, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("037c1dc8-add1-42fc-a0bd-47eefbd4544e"), 5, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4bde037f-7695-4114-892c-809a5e9ea6d6"), 6, new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9bf4ac10-8a06-42d2-8fdc-cb73585ed62a"), 0, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b21ac250-4732-402b-8304-cbde3be29142"), 1, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f6098f69-3389-4ac5-a788-940776adad3e"), 2, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9c86ed96-5856-4f80-99ae-5928809a78e9"), 3, new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("50abe01f-0012-4fd0-b06f-ec46b2c5dfb2"), 6, new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d92e3dd9-bc13-42ff-a414-d181c691ea91"), 6, new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("5d217d9c-fc50-465e-8253-edf067e79e33"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("bd5cb986-15e1-4739-9f83-2a3f196d2350"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), true, new Guid("eeec4ded-e242-4414-bba6-24d803eebb69") },
                    { new Guid("38f2909f-a60f-477f-9c6b-2eae52e32c88"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), true, new Guid("eeec4ded-e242-4414-bba6-24d803eebb69") },
                    { new Guid("fe955e38-8666-406b-88f3-0d6d072d28e8"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), true, new Guid("4953e86e-0b3b-4c4e-b854-7875bdad3b2c") },
                    { new Guid("ed9400b3-7f0b-4ed2-922a-ad2a19e7275f"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), true, new Guid("4953e86e-0b3b-4c4e-b854-7875bdad3b2c") },
                    { new Guid("dc21d955-e060-4dc3-9e07-dc7e33bb04d8"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), true, new Guid("51bb3144-fd37-40af-adb5-707bccdccb47") },
                    { new Guid("3744c2df-dd6c-4355-bd7f-2bdf29a9230d"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), true, new Guid("51bb3144-fd37-40af-adb5-707bccdccb47") },
                    { new Guid("4e54fb07-2483-46ad-aa5e-dfc1947a2c28"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("445ddf4d-fb3b-4a68-a89b-d03723f184f3"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), false, new Guid("eeec4ded-e242-4414-bba6-24d803eebb69") },
                    { new Guid("d55f4dae-1b53-4d5a-8558-aa01a5c181bc"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("28b5a239-3019-410c-9531-57df930b11e3"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("7a4bd395-30f3-49d2-8a12-1c2810d51103"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("15c08b01-a20d-451c-b692-70420bbc44ac"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("660f3258-77fb-4451-b802-50a72655d33f"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("e761da8d-6c89-4152-a897-e06c5b4b2986"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("53bda973-6f7a-4901-8b9f-f7ddb923d678"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), false, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("e9b66523-b7b9-49ff-ae0a-54c5906d0fd8"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("e8d822c1-ea69-4c1f-9e46-408fbe5f0580"), new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("01f50464-d2a5-4db9-a237-b643dcd805da"), new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"), true, new Guid("0ba92e39-a69c-4990-82a5-442adb6ef5c3") },
                    { new Guid("49b542c9-9e1b-4ff3-b707-954e581b1f5d"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("44ac6825-f789-4430-b283-9a2ba22ea258"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), true, new Guid("222dd73b-f392-499a-8c6c-cd5ba6155c7f") },
                    { new Guid("9be7f633-2d9b-41da-b4fb-01186ddd379e"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("5a2cedfb-0213-477d-afda-fb4656636e4f"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), false, new Guid("6f67893c-337a-4c9b-845e-5ffdce460b61") },
                    { new Guid("89c63b0e-0290-4071-b74a-f8bc22131c3d"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("2d500d54-7091-40e4-920c-dfd921087a6f"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("60aa84c7-27c3-4fc4-abb7-ccf90618d785"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), true, new Guid("10ddac69-7943-4090-afea-a7eea423608a") },
                    { new Guid("6b9beffb-65df-4561-a3f6-7708b1efb74e"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), true, new Guid("6f67893c-337a-4c9b-845e-5ffdce460b61") },
                    { new Guid("239f4f6e-ba97-47ed-bef9-5a102ed61b73"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("c34b4c1d-f4cb-40df-b569-f7ff30e42d06"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), true, new Guid("82ada276-374e-4be0-9a62-56090872b554") },
                    { new Guid("a17c4bc2-c06c-4ad9-9ea9-388cc8a59427"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), true, new Guid("6f67893c-337a-4c9b-845e-5ffdce460b61") },
                    { new Guid("333796dc-e24f-4e87-9c4e-e4d438fa94ee"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), true, new Guid("222dd73b-f392-499a-8c6c-cd5ba6155c7f") },
                    { new Guid("dd255440-10d7-4d51-befb-8a74a94815e4"), new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("31dbed55-0d83-4e94-8c0c-6cb878db104a"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("2bda75b7-3d6f-4ed1-8e27-b9ff7fa7190d"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("c5152f80-7226-4f06-88b0-46560ffe85ae"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), false, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("e4f501c1-d075-4e4e-8728-80303017ccaf"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), true, new Guid("10ddac69-7943-4090-afea-a7eea423608a") },
                    { new Guid("dff536e3-5910-4c32-b6ee-11d7fdd7f925"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("243107d1-3069-4aa7-8c29-076deb684520"), new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("6784b527-e83d-4f0b-a527-cedd955151ed"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("1b8204bc-38e5-42b5-942a-5177437acc7c"), new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"), true, new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d") },
                    { new Guid("df7c2269-60fa-4fc7-84ea-a47f7585c944"), new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"), true, new Guid("c59e9707-ba51-471d-afa1-986506028b92") },
                    { new Guid("fc59458c-4147-4dc6-8429-a3534a86ea9f"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), false, new Guid("40f8dd46-71b7-46c3-94bb-526808a5e67f") },
                    { new Guid("36dd06d5-ff3b-48bd-89e7-9c9893a608c7"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), true, new Guid("4e2c95ff-192c-4388-8a6f-cff9b1cd0ded") },
                    { new Guid("260ae942-e0ff-4369-a236-bae8c0adcf9e"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), true, new Guid("140b54b9-cc37-4071-ba5b-58da06c8548e") },
                    { new Guid("b18ed549-d4de-46bc-bb0c-22794c0559d8"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), true, new Guid("140b54b9-cc37-4071-ba5b-58da06c8548e") },
                    { new Guid("3bfb76e7-83d4-4680-a3af-1824b0069e52"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), true, new Guid("9f4c991f-7cd2-4c59-b58c-e748d4a77e7b") },
                    { new Guid("c1fcd971-8c84-4ac8-85aa-09cec63cafd9"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), true, new Guid("9f4c991f-7cd2-4c59-b58c-e748d4a77e7b") },
                    { new Guid("16bae1c4-b61a-44f8-8a99-f6ccc1c7b6fa"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("5f4c86da-e9eb-4f3d-b334-9817d3f23bc4"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("64d261d5-1aea-4638-a103-604c815f88a9"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), true, new Guid("4e2c95ff-192c-4388-8a6f-cff9b1cd0ded") },
                    { new Guid("b8e06dca-fa86-4523-b85f-07250b4e9d88"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("abb6ad64-55a1-4546-88a3-1428fc45623c"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("2e8bfd0c-547e-4067-af83-c13998a973d8"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("91e81252-dcee-4b85-97b1-dd3a905b69bf"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("8fc77a76-4636-4752-bb34-1be0d9efc47d"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("c7c12e7a-4c59-44f3-9375-d893a96a7acf"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("c467b36f-453f-44b8-9f8f-eb0623580185"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("63b7f845-1ee4-4134-8c5d-802d719d9d25"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), true, new Guid("3ee45a20-a9ad-4781-82ed-bd099087f80b") },
                    { new Guid("5be24172-a034-4da4-8069-bb0732c2696c"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), true, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("e199fc35-ee09-4230-a2dd-036c5701b6a2"), new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"), false, new Guid("4e2c95ff-192c-4388-8a6f-cff9b1cd0ded") },
                    { new Guid("29194c7d-880e-436b-89ea-fad6740d1ee2"), new Guid("8c922905-6966-4529-9eeb-a25185e99503"), false, new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26") },
                    { new Guid("6dad6995-a5b0-47ab-95fb-4aaeb6cd5afe"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("8082e29c-b153-4c28-90bd-03e44032843a"), new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"), true, new Guid("7834624c-5399-4275-86ba-4048c1cf343f") },
                    { new Guid("ec5ae05c-f3bf-494b-8b6e-ef2a64b227d2"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), true, new Guid("40f8dd46-71b7-46c3-94bb-526808a5e67f") },
                    { new Guid("7974cb01-4a4f-42e8-aba7-c77e2ab1e96e"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), true, new Guid("017e560b-3716-4468-b4cc-e2c61ee4d057") },
                    { new Guid("abaad8d8-4461-4cf1-a4c4-77864de80674"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), true, new Guid("2d9e9db2-e2a3-4eb7-aa93-bf639b657dd1") },
                    { new Guid("e8a10059-702c-419e-8bce-eb0a4b732678"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), true, new Guid("2d9e9db2-e2a3-4eb7-aa93-bf639b657dd1") },
                    { new Guid("4cb6cb8f-6855-484d-a745-7e1edfd8658d"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("2a537b3f-056c-46f8-9f5e-0527631fd427"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("75460a63-7cdb-48ce-aec1-c5dc9628fc03"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("7d36a76d-bacc-49eb-8697-2d2f7e648ed5"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), true, new Guid("017e560b-3716-4468-b4cc-e2c61ee4d057") },
                    { new Guid("e4ddd962-f775-4a89-9238-d5eb5f2947ca"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("a07c3c8a-6367-49fc-b668-e181dc8bd383"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("e1429192-fba6-4bc5-910e-220e57ea033c"), new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("39a64771-c1f3-4285-9bc2-0b79e6f3ec1b"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("9ad170c4-f42d-4ea1-8f20-9e348a8fafeb"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("eea1276e-0e18-4762-a7d7-4548c546d146"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), true, new Guid("40f8dd46-71b7-46c3-94bb-526808a5e67f") },
                    { new Guid("f57a312a-9bbf-4f19-82de-7a89dfa539be"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("12d088d5-c40a-4d82-9a1c-1a769286d99a"), new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"), true, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") },
                    { new Guid("163b61eb-e56b-402b-9798-dedb27451410"), new Guid("cdf31cb5-3080-4b6d-9460-808189352444"), false, new Guid("b7df519d-8447-4826-a56f-f5f3b1726510") }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ac19b341-68a1-416b-b443-95fa68b1be64"), 5, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("af934bfc-5bd6-4bc8-8093-cbe534a79e23"), 5, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("50280cc6-08fe-4ed1-aa89-f4baecb73de2"), 4, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("94120d5d-be60-418d-b39c-83301c35295c"), 3, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("baf8b95f-c9bd-4039-85c4-b2906572f302"), 2, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d907fa89-3718-449d-ab8b-4468aa9e7844"), 1, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f59fedd3-b8fb-4b43-89b3-c3426eaa18a4"), 0, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bcde5a22-8bbb-4791-bc44-5649d7491452"), 12, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b7976a3e-3f62-413b-96f6-d168bb455983"), 10, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("04f62a44-9abe-4129-b347-8356794d73b4"), 8, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0718099-4dad-4d6e-ac0a-025aadb2d526"), 7, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8323bb2e-9d69-4d11-b13e-016e9473ee7c"), 6, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c27367f7-7054-4c68-9aec-015d6173e70c"), 4, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f71f3340-9eb3-42c5-971e-8256269620e8"), 6, new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6b90f669-a9e5-4479-9390-e3bb06726936"), 11, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d35a0ab4-446b-4cd6-92dd-d4ae0fa2e314"), 9, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("27b7f83f-ff9b-4906-9626-52ab483c572b"), 7, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7851ad16-bb06-485d-9d8c-337351148a62"), 1, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4bc59b7d-8cae-468d-9d52-16c02dca04d7"), 4, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e9f91104-b846-48aa-adc5-7d02fd5e54e4"), 3, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7acaf5d7-4058-45dc-b02c-fdbf1f4e34bf"), 3, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f995f02-f681-416e-8234-f1f16e9d98e5"), 2, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c1d8623c-4bcd-4d62-b35e-a924fac95ba2"), 1, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a5a4759-2c40-4317-a108-8df69f9496ce"), 0, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c00609d-9579-471d-b44b-9db22eba46ef"), 0, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9dd0615b-c2ac-4eb0-8233-85bfdf9a1363"), 10, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3b73cb85-654d-4b00-b849-3cf0f7ab58ed"), 8, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da307047-4981-4d81-830b-5f4b5d45d327"), 6, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ad8bb001-8418-4c27-9565-fe91153ae3f6"), 5, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("942b957a-3681-4f39-bef1-247b7b9bf969"), 4, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c7933a2a-b795-4287-8366-a5ac2ab02520"), 3, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d4cf189a-8f6f-4cd4-8d92-67f8784b38e3"), 2, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fa29255a-5ff5-4694-b79f-8d04f5832b0a"), 9, new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("541a5468-6605-4f30-82c2-74c074afa84b"), 2, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f694fc14-20df-4997-9167-0dde44013047"), 0, new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9260551d-7c53-4fce-b502-7b20a33a19ee"), 0, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("91a3a511-8183-4ee1-91b6-3737cb7fc3c1"), 5, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36d1012c-ec10-4b65-b082-8638c61381a6"), 4, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("900ae343-cd77-4a2b-b616-b6022de8e4e6"), 3, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c8fd0030-7403-4bb2-8afa-6f07c4d727d9"), 2, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d3ef9152-9114-43f8-8c9c-eeb882bd2a34"), 1, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("10ca81f7-3b13-442c-8c52-16bc439e771b"), 0, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("916a1d79-cd60-4ab4-95ed-e5966e41095f"), 6, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2e8c41f9-76ad-4621-ad31-a1ff644bd87c"), 6, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4caea851-e412-4637-a447-b6c966262975"), 4, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c9a6fb80-8237-410c-b5e8-dd1c24a7c04f"), 3, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a6935dc8-28a9-4d93-83d6-33b0205630e9"), 2, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0f4f5f4d-45b2-48c2-906b-8b5e2469f8ab"), 1, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf08f238-a447-41a7-8c4e-c254677c0d99"), 0, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cb79eee2-9c5d-4979-83f0-521244f2cf13"), 5, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8772e703-c021-41c7-8545-fbd5762089e4"), 5, new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cd1cf111-f580-4619-91de-8d69397c4770"), 1, new Guid("bc728e45-99f0-4779-be69-b90c323186e9"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7351a2d2-3b55-4167-8e7d-891427b755ff"), 7, new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("03f17556-0393-4358-b4b9-71ce598dbde5"), 2, new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1c567ebb-0a30-4f25-a967-97ce319db25f"), 3, new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1b38e235-9567-4dc1-81bf-235dd9fd5f9e"), 2, new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b94b0d86-c41a-4c9e-a271-3d3ae513dc02"), 1, new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6630e91f-8d2d-4317-8496-238e59a1f277"), 0, new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ae4a7d0-b8f3-424c-8712-0308c5bfbf78"), 7, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fdeb1689-c807-4bc5-b481-d5bfb5b2b2bc"), 7, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ebe9064a-aa92-4f24-8350-51e854ab07e7"), 1, new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3d0f8fae-5a7e-4a12-bdab-592852bd5b81"), 6, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ac6b1db-b962-4a59-8a5e-60c27673739d"), 4, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b22786a7-2fa5-4cc7-af2a-4a9757be8196"), 3, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("72111663-8a48-4b19-9fb0-bc057fb32929"), 2, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84ba414a-2930-4adb-941f-018c3c83fbf4"), 1, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("252f349e-cc8e-47d7-b02b-b5315ad9b6db"), 0, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97d89a52-e395-401b-ab88-1d8812961b5f"), 3, new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8fefe3a1-6f6b-4c1e-acef-7a73bdde8d12"), 5, new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e48316d7-d324-4ee1-9acf-6877012176e3"), 6, new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"), "Reverse strong band" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeTags_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeTags",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeTags_Tags_TagId",
                table: "ExerciseTypeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeTags_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseTypeTags_Tags_TagId",
                table: "ExerciseTypeTags");

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("01f50464-d2a5-4db9-a237-b643dcd805da"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("12d088d5-c40a-4d82-9a1c-1a769286d99a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("15c08b01-a20d-451c-b692-70420bbc44ac"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("163b61eb-e56b-402b-9798-dedb27451410"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("16bae1c4-b61a-44f8-8a99-f6ccc1c7b6fa"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("1b8204bc-38e5-42b5-942a-5177437acc7c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("239f4f6e-ba97-47ed-bef9-5a102ed61b73"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("243107d1-3069-4aa7-8c29-076deb684520"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("260ae942-e0ff-4369-a236-bae8c0adcf9e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("28b5a239-3019-410c-9531-57df930b11e3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("29194c7d-880e-436b-89ea-fad6740d1ee2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2a537b3f-056c-46f8-9f5e-0527631fd427"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2bda75b7-3d6f-4ed1-8e27-b9ff7fa7190d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2d500d54-7091-40e4-920c-dfd921087a6f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("2e8bfd0c-547e-4067-af83-c13998a973d8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("31dbed55-0d83-4e94-8c0c-6cb878db104a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("333796dc-e24f-4e87-9c4e-e4d438fa94ee"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("36dd06d5-ff3b-48bd-89e7-9c9893a608c7"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3744c2df-dd6c-4355-bd7f-2bdf29a9230d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("38f2909f-a60f-477f-9c6b-2eae52e32c88"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("39a64771-c1f3-4285-9bc2-0b79e6f3ec1b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("3bfb76e7-83d4-4680-a3af-1824b0069e52"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("445ddf4d-fb3b-4a68-a89b-d03723f184f3"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("44ac6825-f789-4430-b283-9a2ba22ea258"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("49b542c9-9e1b-4ff3-b707-954e581b1f5d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4cb6cb8f-6855-484d-a745-7e1edfd8658d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("4e54fb07-2483-46ad-aa5e-dfc1947a2c28"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("53bda973-6f7a-4901-8b9f-f7ddb923d678"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5a2cedfb-0213-477d-afda-fb4656636e4f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5be24172-a034-4da4-8069-bb0732c2696c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5d217d9c-fc50-465e-8253-edf067e79e33"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("5f4c86da-e9eb-4f3d-b334-9817d3f23bc4"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("60aa84c7-27c3-4fc4-abb7-ccf90618d785"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("63b7f845-1ee4-4134-8c5d-802d719d9d25"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("64d261d5-1aea-4638-a103-604c815f88a9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("660f3258-77fb-4451-b802-50a72655d33f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6784b527-e83d-4f0b-a527-cedd955151ed"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6b9beffb-65df-4561-a3f6-7708b1efb74e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("6dad6995-a5b0-47ab-95fb-4aaeb6cd5afe"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("75460a63-7cdb-48ce-aec1-c5dc9628fc03"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7974cb01-4a4f-42e8-aba7-c77e2ab1e96e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7a4bd395-30f3-49d2-8a12-1c2810d51103"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("7d36a76d-bacc-49eb-8697-2d2f7e648ed5"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8082e29c-b153-4c28-90bd-03e44032843a"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("89c63b0e-0290-4071-b74a-f8bc22131c3d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("8fc77a76-4636-4752-bb34-1be0d9efc47d"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("91e81252-dcee-4b85-97b1-dd3a905b69bf"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9ad170c4-f42d-4ea1-8f20-9e348a8fafeb"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("9be7f633-2d9b-41da-b4fb-01186ddd379e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a07c3c8a-6367-49fc-b668-e181dc8bd383"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("a17c4bc2-c06c-4ad9-9ea9-388cc8a59427"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("abaad8d8-4461-4cf1-a4c4-77864de80674"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("abb6ad64-55a1-4546-88a3-1428fc45623c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b18ed549-d4de-46bc-bb0c-22794c0559d8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("b8e06dca-fa86-4523-b85f-07250b4e9d88"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("bd5cb986-15e1-4739-9f83-2a3f196d2350"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c1fcd971-8c84-4ac8-85aa-09cec63cafd9"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c34b4c1d-f4cb-40df-b569-f7ff30e42d06"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c467b36f-453f-44b8-9f8f-eb0623580185"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c5152f80-7226-4f06-88b0-46560ffe85ae"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("c7c12e7a-4c59-44f3-9375-d893a96a7acf"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("d55f4dae-1b53-4d5a-8558-aa01a5c181bc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dc21d955-e060-4dc3-9e07-dc7e33bb04d8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dd255440-10d7-4d51-befb-8a74a94815e4"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("df7c2269-60fa-4fc7-84ea-a47f7585c944"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("dff536e3-5910-4c32-b6ee-11d7fdd7f925"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e1429192-fba6-4bc5-910e-220e57ea033c"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e199fc35-ee09-4230-a2dd-036c5701b6a2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e4ddd962-f775-4a89-9238-d5eb5f2947ca"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e4f501c1-d075-4e4e-8728-80303017ccaf"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e761da8d-6c89-4152-a897-e06c5b4b2986"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e8a10059-702c-419e-8bce-eb0a4b732678"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e8d822c1-ea69-4c1f-9e46-408fbe5f0580"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("e9b66523-b7b9-49ff-ae0a-54c5906d0fd8"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ec5ae05c-f3bf-494b-8b6e-ef2a64b227d2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("ed9400b3-7f0b-4ed2-922a-ad2a19e7275f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("eea1276e-0e18-4762-a7d7-4548c546d146"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("f57a312a-9bbf-4f19-82de-7a89dfa539be"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("fc59458c-4147-4dc6-8429-a3534a86ea9f"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypeTags",
                keyColumn: "Id",
                keyValue: new Guid("fe955e38-8666-406b-88f3-0d6d072d28e8"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("42007cda-854f-4b13-9b6c-481053539ece"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("46f3282f-1a33-4cd9-baf6-c6fa28a4fa12"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("49620b75-ee76-495e-83d0-f3c689e51571"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("59ff97e1-bacb-4d49-b48e-84e65ac4c2ab"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("5cf9ffb9-9b2a-4f91-b8ae-e771dad7e965"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("60fcd88c-12c7-49e2-9981-bfed933860ae"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("61cc5893-e466-4076-866e-b2f471df6948"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("75b266ed-024d-4bc5-a5f0-5f5d1a1bd455"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("8e322a22-1a36-4387-9393-c8fb90ac0c7c"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("a311bfef-7477-49ec-97ff-7eef1fca06f5"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("e181d0b0-1b67-4d1e-b679-63b8f74fd89d"));

            migrationBuilder.DeleteData(
                table: "NotificationSetting",
                keyColumn: "Id",
                keyValue: new Guid("f8aa736c-c23b-4873-9e2b-33c5a197b691"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("00e4951a-a557-4100-a664-d2fe5fd8fa41"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("02acf8c8-51ec-465e-a3eb-d0a961e9038f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("036889ff-673c-475d-8391-13aa665166af"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("037c1dc8-add1-42fc-a0bd-47eefbd4544e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("03f17556-0393-4358-b4b9-71ce598dbde5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("04f62a44-9abe-4129-b347-8356794d73b4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("053a124c-5779-476e-9228-d7fafbbc95d2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("06ca0aa5-1731-4ca1-b913-96bf3fca1b61"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("08260c23-382c-415f-b6a0-6a66c52b5d63"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0a5a4759-2c40-4317-a108-8df69f9496ce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0abec136-5b04-4dd7-a0b1-c8f6e1420eaa"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0c3f81e3-7258-42c8-a8a4-9b650f9c69a8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0dfef486-7b13-4e30-becf-91a17d95943d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0e04e401-d7c1-4dd5-9621-9a4236a75901"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0e88bb0a-508c-49b8-b217-afeb466e5b0c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0e9ad192-694a-47bd-ac0d-c73fdf25701a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0f4f5f4d-45b2-48c2-906b-8b5e2469f8ab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("10ca81f7-3b13-442c-8c52-16bc439e771b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("113efa6a-616c-4aad-9a6a-09762a644a61"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("14e9aed5-fd05-49d9-9210-5b0cf7b875fc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("15c7b8d9-734d-4058-b784-5595d8e6b9ed"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("196dce35-5cd0-49d3-bebb-a46649d1fffc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("19bb9692-7049-4f5b-87b6-08fc37ffddb7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1a8c4848-3ff6-4b66-8bbf-ed05301e5353"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1b38e235-9567-4dc1-81bf-235dd9fd5f9e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1be1fc23-680b-4a1f-a15c-396b3a67b3f0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1bfed914-8f54-4fde-8a31-fc0b3a6dae9a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1c567ebb-0a30-4f25-a967-97ce319db25f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1cc37bad-1efb-450b-85f2-d39286c1bcb1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1d850321-6674-448a-93e4-c01ba27852c4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1e2f10fa-6ecf-4a39-bfd4-5ed13c0bb9db"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1e333570-172c-454c-973d-bfb0fcc6d7f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("1f995f02-f681-416e-8234-f1f16e9d98e5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("215d80ce-f2c6-4f7e-b29b-ff6be34c2612"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("22a3311b-bb06-4894-87fa-bc557bdae238"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("252f349e-cc8e-47d7-b02b-b5315ad9b6db"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2701eb85-c334-4bf6-8b1e-a3a947ebf6f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("27aa0552-d55e-4618-8fb3-9154776bf5fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("27b7f83f-ff9b-4906-9626-52ab483c572b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2c2c478a-0b0e-4bd7-83a8-3ee9116b7e63"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2c95439e-83e0-4f6f-833a-18a4dc978190"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2db1af96-e104-412e-8bb0-2fe76c0fea29"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2df5ba55-60cd-4292-8860-f4d23a5bec73"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2e388482-6ecf-4c02-9267-c0e5da6f14eb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2e8c41f9-76ad-4621-ad31-a1ff644bd87c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2f9f0b0f-0033-4ff0-a68a-4913db750caa"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("313e639b-4f06-4986-8396-eae2ba6051e7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("324681c5-f3f0-4b74-b24a-e01dccff8003"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34d5fa7e-57f8-476f-b5fc-38f772138351"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34ea6cae-1f9e-4f42-bb43-64751ed81a48"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("36c05f14-932c-4537-b566-1d3449e038dd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("36d1012c-ec10-4b65-b082-8638c61381a6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("384759ed-ac70-4d70-bbc2-4bdf20988270"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("395226fa-317d-416d-b756-c241f221c0f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3b73cb85-654d-4b00-b849-3cf0f7ab58ed"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3bae668c-74da-4dcd-a550-c56951455347"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3d0f8fae-5a7e-4a12-bdab-592852bd5b81"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("433ba5eb-0d3f-40e1-bf38-6cfae51e7021"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4393faae-74d9-4a19-b139-68dbde3c0631"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("43f9a46f-14b5-4943-9a9d-415ace8e2a5a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("442a95d3-2908-4049-9f88-4cb78817ff4b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4487e2b7-a373-483a-95e6-e51efe4fe786"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4505ddfe-0736-4489-a7e9-0aff20f72e67"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("46290264-fb2d-4577-8a17-b7ecfb24d1d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("46a93b97-eb4e-48bb-8eda-8a779d94bb66"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("46f929e4-ca70-4171-a780-87826c61f54b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("471d4efd-5ff8-4ac1-8470-c215ba468f69"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("47393843-df95-4838-bbe9-c5c26d4d5d2b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4bc59b7d-8cae-468d-9d52-16c02dca04d7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4bde037f-7695-4114-892c-809a5e9ea6d6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4c00609d-9579-471d-b44b-9db22eba46ef"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4caea851-e412-4637-a447-b6c966262975"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4ef96a0a-97b1-451f-9793-90c072ba1e85"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4f343a53-668c-47e1-a5cb-aff361c0c496"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("50280cc6-08fe-4ed1-aa89-f4baecb73de2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5059acea-9513-46c3-8e49-71a23d2eec72"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("50abe01f-0012-4fd0-b06f-ec46b2c5dfb2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("541a5468-6605-4f30-82c2-74c074afa84b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("54e685c5-9285-4446-8f42-f88ae581d30a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("550b2027-e428-4712-8032-8f0c8e492d3a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("580bf4dd-bfce-4112-8fb2-1f6f18426e05"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58195b49-8112-4ea8-b29b-6046a3e00a05"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("58eae981-cb7b-4479-ac68-fbfb6eef70d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5cc64b12-3f10-4d96-b53c-fe8db4c4a876"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5ccc936b-b803-48cc-a216-f3ab25d0aa06"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("5f48bb5e-2b43-4f44-8204-5349bc7b7712"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("60253084-ca72-442a-9e72-ccd3de0ef9d7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("60bdf5d0-7ec3-4bf9-88dd-d7c90a2534c4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("63587a3f-82d2-478d-a713-4e292d8d3619"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6630e91f-8d2d-4317-8496-238e59a1f277"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("66c9cf24-fe30-4662-a833-f8c05310c6f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6717ff52-b7f8-48f3-b2d3-e5e52930930a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6731ea3c-c92d-4fe3-acc7-ac340bfeebaf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("69842641-98df-42e0-affe-516647009921"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("69e447ec-6b14-4dc7-aab3-f6fcf3a482f5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6a9719fe-eaa3-4379-a0a9-a28908954fdf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6b8912d8-7db0-4042-aef9-8d8c3c99d25b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6b90f669-a9e5-4479-9390-e3bb06726936"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6d37e54f-994d-4c61-9ca2-5562334ba749"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6ed9fe43-1863-412c-b913-1062a4bad3c0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("72111663-8a48-4b19-9fb0-bc057fb32929"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("72d02287-eb3e-499a-9b69-1108ecee1069"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("733a45bd-09d8-4e3a-ba1a-a7709697972c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7351a2d2-3b55-4167-8e7d-891427b755ff"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("75f0b405-0fea-4490-b352-a4d2bdf40857"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("77882298-5d2d-498f-b1ff-2440dabadac3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("77db74b0-ec79-449f-b6b5-ccc944d095bc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("78016f37-f2d1-4c6c-8231-c123611f0cac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("78270e2b-2670-4b4a-a2fb-f77566a1be51"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7851ad16-bb06-485d-9d8c-337351148a62"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7acaf5d7-4058-45dc-b02c-fdbf1f4e34bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7ae4a7d0-b8f3-424c-8712-0308c5bfbf78"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7b1bbb8a-d32c-44bd-9d7d-75813bfd3a83"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7b76acc7-49e1-40b0-b238-3351a776d295"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7cbe9127-4dbf-480b-9918-1497dffbeb38"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7d99213a-2f19-42dd-a9b6-780ff25bd369"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7df2fdf8-4da9-49aa-9164-0b1376e69d80"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("82d0d728-d5cd-4279-938d-fc1d1e760b64"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8323bb2e-9d69-4d11-b13e-016e9473ee7c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("83519c42-828f-48cd-b7dc-930318182164"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("83af7320-0dcc-45bc-a02e-87a64f33bf79"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84a8d235-11a6-4c5e-9e5f-d08a824b7350"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84b7f3e5-8508-424d-8b38-5e3548ccb82a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("84ba414a-2930-4adb-941f-018c3c83fbf4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("851e6458-b3d9-447b-9d88-1b1cf11a6021"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8547c341-42ba-4768-80b3-9957063eda5e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8772e703-c021-41c7-8545-fbd5762089e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8824207a-130f-45e6-959d-985e3cb930a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("898b54cb-157e-4e4c-9eef-de905af16a1a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("89933abc-76a5-427c-92ae-b4a09ba8cf32"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8bf8b971-4242-494a-af76-7c4335da5dce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8db54080-2642-46a0-938f-eedf11ec3f6d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8df122d1-9b65-4419-bde9-ba2101f65962"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8ecf87e1-424e-49e1-99e7-d429b3667a99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8f85c20b-a44d-4a40-9696-c8d43746c48c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8fefe3a1-6f6b-4c1e-acef-7a73bdde8d12"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("900ae343-cd77-4a2b-b616-b6022de8e4e6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("913c60dd-0f86-4650-a699-2b06663658f3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("916a1d79-cd60-4ab4-95ed-e5966e41095f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("918193c4-d1ed-4333-b734-cebd44b120fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("91a3a511-8183-4ee1-91b6-3737cb7fc3c1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9260551d-7c53-4fce-b502-7b20a33a19ee"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("92ffd2c2-c19d-446a-9fda-9e4ee38591d3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("94120d5d-be60-418d-b39c-83301c35295c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("942b957a-3681-4f39-bef1-247b7b9bf969"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("96d3d992-8868-42d3-9bac-2b94589f58bf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("96ea5e50-5f15-49ef-b9d3-c9e56601b49c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("97d89a52-e395-401b-ab88-1d8812961b5f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("999175a7-9ac3-4702-8179-08beb430753f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9a90c283-f8b2-414e-aa30-d9885c814a1a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9abb7931-7f0c-4af8-8692-d1e3df2167b9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9ac6b1db-b962-4a59-8a5e-60c27673739d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9b026adb-09e2-42ba-a9cc-9fb135627ace"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9bf4ac10-8a06-42d2-8fdc-cb73585ed62a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9c86ed96-5856-4f80-99ae-5928809a78e9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9dd0615b-c2ac-4eb0-8233-85bfdf9a1363"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9de05a0e-f722-407a-8f43-13b7005c37fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9efa99a5-53b3-4915-a455-fcc2ebde5fdc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f1a04e7-ec45-48f4-b79e-6f1ee9e12e76"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f425b62-430b-4c56-be71-506885efd7ca"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f5d6c27-bce4-4b77-84ac-48d42895c0a2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a0906b97-a00f-44b0-8c11-da51222ee50a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a3a0266a-9081-45a6-9345-85a9d5a2b0df"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a530335b-b9a1-457c-bd33-1589c2a64ac8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a555cea3-a83e-422d-9634-9e5fe7aefd3a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a646bffd-4f64-44ac-ae11-795595fee461"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a6935dc8-28a9-4d93-83d6-33b0205630e9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a7423d01-bd34-4f5d-9f28-46fccfc1cfc5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a83f2f85-8d54-48b0-bd72-da69cd475dd8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a8d069ae-d975-4ae8-9b7b-4bea544194f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("abe4cd55-70f0-4d59-aa93-4e1504cbf2ce"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ac19b341-68a1-416b-b443-95fa68b1be64"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("acc341e8-d2a7-4080-926d-c852b250544d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ad8bb001-8418-4c27-9565-fe91153ae3f6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("adb8f12c-17a5-4ec1-a7e2-7154ee82038a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("af10ed1d-8685-421f-b048-85d3c699343c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("af934bfc-5bd6-4bc8-8093-cbe534a79e23"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b0718099-4dad-4d6e-ac0a-025aadb2d526"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b1790ff1-297b-4342-b7bb-f870eefb054b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b21ac250-4732-402b-8304-cbde3be29142"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b22786a7-2fa5-4cc7-af2a-4a9757be8196"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b24b575b-d4f3-433d-8e6d-9b2bef823346"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b40616be-33d8-4436-99ef-594711e81194"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b4434eb5-cf47-4a88-8969-835485b863e5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b45bb1c4-67a2-4a54-a3ac-5ab478ef9389"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b48f4433-bae8-468a-adc1-0e443f0f64e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b6926860-f4a8-4c2f-b2e0-58cecc91cd5b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b7976a3e-3f62-413b-96f6-d168bb455983"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b863e74b-b17b-4b52-a907-de563cc053d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b94b0d86-c41a-4c9e-a271-3d3ae513dc02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b98a27f5-0de8-4676-94ef-65d1399b622e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ba0c5e31-4d50-4d9b-a240-f383aef07835"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("baf709bf-6fd4-4752-bf21-806a55a47d1d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("baf8b95f-c9bd-4039-85c4-b2906572f302"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bb342297-f881-44f5-aea8-658f59cb92ba"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bcde5a22-8bbb-4791-bc44-5649d7491452"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bdc3f1c2-6a7d-4444-b538-e711c30a4369"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bf72a61f-80d5-4800-84f5-22472f9de4c7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1a18a65-f92f-4106-80c5-a7b049f9d992"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c1d8623c-4bcd-4d62-b35e-a924fac95ba2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c27367f7-7054-4c68-9aec-015d6173e70c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c323c699-e60e-4630-b28c-a67c9329642d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c43ded62-68fd-4337-8a0b-2cd4bc3e9e3a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c4e2fc2e-bd22-43fa-926f-5d96969fbc46"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c4f65dbf-1416-405a-b734-88c3b3c2c147"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c69d672c-2b09-4d49-9263-b6399f961390"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c7933a2a-b795-4287-8366-a5ac2ab02520"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c8fd0030-7403-4bb2-8afa-6f07c4d727d9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c9a6fb80-8237-410c-b5e8-dd1c24a7c04f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c9e48370-1613-470b-9be9-c55f8fb86d50"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ca430845-2e72-46c1-8cc0-9d968f31ba61"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ca435e46-fa52-4f54-815f-fa263800dbcd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cb79eee2-9c5d-4979-83f0-521244f2cf13"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cd1cf111-f580-4619-91de-8d69397c4770"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf08f238-a447-41a7-8c4e-c254677c0d99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf1a1c83-de64-452c-99aa-ceff0492af73"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("cf5f28f1-394f-4235-bd5b-eb10176a9333"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d35a0ab4-446b-4cd6-92dd-d4ae0fa2e314"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d3c08db5-3d17-45fe-978b-69b67be5106c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d3ef9152-9114-43f8-8c9c-eeb882bd2a34"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d4cf189a-8f6f-4cd4-8d92-67f8784b38e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d5f57771-c53c-4e2c-a8e7-21ac9a8d6230"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d7cf1538-21e2-4ea8-b231-e194be636f83"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d81a9249-f52e-4161-90c4-af023d839ea5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d82e1c77-2bb5-48ce-92c4-499b5117fb2f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d907fa89-3718-449d-ab8b-4468aa9e7844"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d92e3dd9-bc13-42ff-a414-d181c691ea91"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("da307047-4981-4d81-830b-5f4b5d45d327"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dde3c86f-2428-42f1-9a4b-d0eb6ae78935"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e04b0e68-1b07-4a99-aac5-04bb5be0c02d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e1dbfcc3-3e9f-43b1-91c7-96a7543e1162"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e268aeea-21b4-4114-a086-96e4c78de026"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e2f1d724-4d7c-4334-85fa-af5c07174012"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e446ac85-b5b5-4069-849b-2bb4c98b8372"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e48316d7-d324-4ee1-9acf-6877012176e3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e63d37f3-b1f5-47ff-baa0-4c5000536934"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e7a20e5c-e71f-431a-9815-e5249aef3828"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e927a5f4-d6bc-4169-9ce2-6de307210c30"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e9f91104-b846-48aa-adc5-7d02fd5e54e4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("ebe9064a-aa92-4f24-8350-51e854ab07e7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f1f2e8c6-79d2-424c-8fd3-bab86b4be089"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f23d9d04-a5b1-4aa2-b1cb-6c86e556dbcb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f2ea1a2a-9f38-4bde-9612-5a9c8801dffb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f4ccf2e6-bbc1-48a2-98fe-d791e31fb791"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f4d43f80-da84-4753-ba1c-47047bfa89ec"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f542d33f-d309-4104-ba30-ec367154ea86"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f59fedd3-b8fb-4b43-89b3-c3426eaa18a4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f6098f69-3389-4ac5-a788-940776adad3e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f694fc14-20df-4997-9167-0dde44013047"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f71f3340-9eb3-42c5-971e-8256269620e8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f74249d0-4a53-4fb9-a1c7-15cd644d135a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f84250cb-5fce-4b01-b21d-82512e9a1a7e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f8dfad82-1b75-4d8a-8709-49c8dffef3da"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f9ca66da-ad1c-4fc7-a5d3-82b708ee9ad1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f9dcd52b-d111-4ef9-9a3e-eb5a553cf355"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fa29255a-5ff5-4694-b79f-8d04f5832b0a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fc22feaf-4cac-424b-838d-f5ffe8ebb165"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fdeb1689-c807-4bc5-b481-d5bfb5b2b2bc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fe8ddef1-1579-4db2-ae80-ece4539a3578"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("fec24f70-3429-4294-b8b8-58732f19afbc"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("0e9f030b-2156-484b-8777-f7b0153bd476"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("472ddd24-9a65-4e74-a816-708d14584e4e"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("7a1230c0-f694-48f7-98af-cbdeed362b43"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("8c922905-6966-4529-9eeb-a25185e99503"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("aa9e4102-dd51-4a5f-abe6-5f3593699809"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b7415078-d298-428c-8745-f5a5a0faf9a2"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8f82777-1243-4c8d-a5c9-088e26744af4"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc4d51bf-553d-46fa-b7c5-b42189af78fb"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdf31cb5-3080-4b6d-9460-808189352444"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc16e394-2be9-49db-bb37-bbc1681e8e4b"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("df4aad97-6db3-4e2f-aaf0-994451186477"));

            migrationBuilder.DeleteData(
                table: "ExerciseTypes",
                keyColumn: "Id",
                keyValue: new Guid("e3f7797a-7098-4872-b9c7-204f859b2b2e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("02846e19-4c78-4f50-9d3a-ce0981e57fc4"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("03fdec1e-73cc-4ae7-abe7-4a6e6cf7d603"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("0f1f42cf-7808-417c-a541-64b8ef8c3a99"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("15847986-1ca8-4e8f-869f-37fd855e1879"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("1fb4c505-2426-480e-aec3-88b0a1561607"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("202e7bef-e82e-492d-93df-b882d7c964bf"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("476dbcc2-d1de-41c1-8fb8-51b9809ce4de"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("48bcf44c-57b8-4ead-bca8-f3c8923b3eb0"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("4aca7df6-873e-418c-b51a-abcfee80e78c"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("5d63d91d-ec23-4150-9f99-183bab2812b2"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("60f070a6-7aa0-47bc-84a4-b05d2f68650a"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("7127dc12-5b37-4d33-82d8-9f63ddd7aeba"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("78e47db6-ba61-4d72-ae1e-8ac35a4343b5"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("8b082afe-e14c-4cd2-8f45-b8b321679095"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("90149d99-8d07-4e10-8561-04fd0659e75f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("9be4d296-6554-4cc6-8dec-11b593fc15c7"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("a64a33af-ec60-4c2b-bd23-469bc108990f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ad750baa-e2a4-442a-a521-447a8018b739"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ba93a4b0-51b0-4635-b151-1a9d508da581"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("bc728e45-99f0-4779-be69-b90c323186e9"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("bd5be0ea-5fff-4e7d-a79c-75996bb340fb"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("c426801f-0904-4d70-a42a-f066fbabdf14"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("ccda0482-ad76-4009-be38-3bcfd3366cc4"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("d9e0ccfb-5739-4137-b69c-e8b2536d4dd5"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("da87cc7e-b336-4c18-a4ed-721da175127f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("dcda8d1a-9fc0-42ba-b449-bad6a06eb12f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e4e50881-b19e-438c-8f5d-d001278df7e6"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f38dba01-fad0-4ca2-8b31-4e9682dec09c"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f72d92a9-16d9-492d-9226-e9e529e740df"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("fbb2126c-c48b-4ba7-a528-8c1df0b0f60c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("017e560b-3716-4468-b4cc-e2c61ee4d057"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("0ba92e39-a69c-4990-82a5-442adb6ef5c3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("10ddac69-7943-4090-afea-a7eea423608a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("140b54b9-cc37-4071-ba5b-58da06c8548e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("222dd73b-f392-499a-8c6c-cd5ba6155c7f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2d9e9db2-e2a3-4eb7-aa93-bf639b657dd1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("3ee45a20-a9ad-4781-82ed-bd099087f80b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("40f8dd46-71b7-46c3-94bb-526808a5e67f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4953e86e-0b3b-4c4e-b854-7875bdad3b2c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("4e2c95ff-192c-4388-8a6f-cff9b1cd0ded"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("51bb3144-fd37-40af-adb5-707bccdccb47"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6f67893c-337a-4c9b-845e-5ffdce460b61"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("7834624c-5399-4275-86ba-4048c1cf343f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("82ada276-374e-4be0-9a62-56090872b554"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("9f4c991f-7cd2-4c59-b58c-e748d4a77e7b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("b7df519d-8447-4826-a56f-f5f3b1726510"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bb3c4244-9f86-4a6c-a38d-4dcb24567f8d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c59e9707-ba51-471d-afa1-986506028b92"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c87b9042-97a3-4369-8bfa-a6b301f00f26"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("eeec4ded-e242-4414-bba6-24d803eebb69"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("01d00039-2c2c-49a8-be2d-d0a208c25482"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("715ac2b6-8281-49ec-abd3-a22b6c1ca78a"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("c4167e7a-82f5-4200-99af-bc0a46ca229f"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("db07e313-9eda-428e-86d3-5a4b301bd7a5"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("e37b3f43-0727-4f0f-b4d4-cc3f3c4aa95e"));

            migrationBuilder.DeleteData(
                table: "TagGroups",
                keyColumn: "Id",
                keyValue: new Guid("f2e04f0a-47ac-48ab-b14a-3b10a5936c8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94ed241e-86c5-41a9-bf29-8ea4385ecf1c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ce1bbef-b410-4ff2-98b7-560c098e9270"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("2141d935-3b9c-4734-abb8-3ede32752166"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("43586d3d-51d9-4e88-9633-d04e197db885"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("873b3a79-d62e-4945-ae0b-a22e8dd67cc0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65e21530-bba3-45c7-ab68-06960c2dc6c7"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("4c699b31-6665-4a2d-bd0c-220365664b09"));

            migrationBuilder.DeleteData(
                table: "UserSettings",
                keyColumn: "Id",
                keyValue: new Guid("6adde0f9-dbe8-4b4f-a1e2-36b5c88d11c2"));

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("d56051cb-4751-4a11-b72e-e762e42fc762"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "UserSettings",
                columns: new[] { "Id", "ApplicationUserId", "RpeSystem", "Theme", "UnitSystem" },
                values: new object[] { new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Rpe", "Light", "Imperial" });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0ea0a473-abca-4d6f-b338-3805d31a96bd"), "TrainingCreated", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("4f334f0f-b588-421c-a312-98b6db1fea58"), "NoteAdded", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("2b5bcc30-8676-436a-b38a-341e6623e1c2"), "MediaAdded", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("0c8a5182-ef12-47c6-af9d-381a11ff03ca"), "TrainingCreated", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("6688dbb1-f2fa-4368-b050-9958b4d334d7"), "NoteAdded", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("f863aba1-ec6d-446b-8172-44d6f5b540ab"), "MediaAdded", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("993bff72-f307-42c6-9127-89219b1f251b"), "TrainingCreated", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("d2c7954e-9348-4208-ba1b-87950598f6ab"), "NoteAdded", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("b6178cdb-216b-43bd-a77a-821204668741"), "MediaAdded", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c84ae76a-392f-465d-9076-04cf85f1a436"), "TrainingCreated", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("bbd1f8a0-ba0c-45df-b12f-ee91cf0ff8c0"), "NoteAdded", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "NotificationSetting",
                columns: new[] { "Id", "NotificationType", "UserSettingId" },
                values: new object[] { new Guid("c2bbf800-8e8b-43f4-abcc-1fd1dabea2e8"), "MediaAdded", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "User", null, new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(1423), "cus_FLi7gZv8w0j0GB", "admin@trainingcompanion.com", "Admin", "Male", "", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", new Guid("d54a6df8-0c4a-41eb-8f8e-43e469f195a2"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username", "CoachId" },
                values: new object[] { new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "User", null, new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(6050), null, "athlete@trainingcompanion.com", "Athlete", "Male", "", "23a1f74bc589fe525387f8d2c40f1e552a564fe5de00af935bb7a0592fc976c6", new Guid("64a9c8ce-e638-4284-a16c-f3f8236e3994"), "athlete", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "User", null, new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(8277), "cus_FHk5RepADdfm5H", "coach@trainingcompanion.com", "Coach", "Male", "", "e0f167bc84b881bc06f6884fb48e02f41dfc5579e25489db6c6bde238e4aed15", new Guid("d56051cb-4751-4a11-b72e-e762e42fc762"), "coach" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountType", "Avatar", "CreatedOn", "CustomerId", "Email", "FirstName", "Gender", "LastName", "PasswordHash", "UserSettingId", "Username" },
                values: new object[] { new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "User", null, new DateTime(2019, 11, 10, 2, 12, 3, 79, DateTimeKind.Utc).AddTicks(6715), null, "solo.athlete@trainingcompanion.com", "Solo", "Male", "Athlete", "304301ea5935cd1d38e55206e09eebcfe95fcb56f96ddf0ef2d8557a295728c8", new Guid("73c938c2-4cf6-4cc9-ae47-16a987ff27c2"), "soloathlete" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("b2cd252d-d2e6-41e7-810a-906a11417d26"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("5ac43887-533f-4813-8cdc-e3bc061fc091"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("39af0487-69b9-46c6-b2bf-682bff327c33"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("ce3915d8-0e3e-4b04-99b2-34eabc9232bc"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("8f518afc-a67c-4a55-9d68-b709707eb949"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Squat - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0c6d4916-ca2a-4ba7-9425-533bd8d18569"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("a2400fec-dbfb-4ea2-a205-9b9f7e96b9be"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("6baea34a-641e-42c6-a5ea-6402b2d248c5"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("0299d6af-89f4-4c54-956b-59aa61796fd7"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Bench press - competition" });

            migrationBuilder.InsertData(
                table: "ExerciseTypes",
                columns: new[] { "Id", "ApplicationUserId", "Name" },
                values: new object[] { new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), "Deadlift - competition" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("c0786318-d7e4-4965-8788-0126104224a0"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), new Guid("d5e5270a-59c4-485d-9d35-0bdb05f267f4"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 1, "Bar type" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 2, "Bar position" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 3, "Equipment" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 4, "Grip" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 5, "Range of motion" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 6, "Stance" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), new Guid("09bc8fed-c41f-4599-9fb9-2f7492ce8037"), 7, "Tempo" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), new Guid("9b359280-a8db-47a1-9813-7681f8e8bb7c"), 0, "Category" });

            migrationBuilder.InsertData(
                table: "TagGroups",
                columns: new[] { "Id", "ApplicationUserId", "Order", "Type" },
                values: new object[] { new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), new Guid("20999ed3-6364-43e6-9cc2-bb00cae9a2d9"), 8, "Load accommodation" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab"), 0, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("614b3ead-19ff-4e89-a812-87b29a92e331"), 5, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97e331a8-1e12-4a96-8b89-2d8c08717d3f"), 6, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d91643ef-ea82-4316-8cd0-e8b2c7b3299f"), 7, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29fb511e-d0c4-465d-9265-52ae824cf081"), 8, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f153ef29-b4ee-49a9-8558-7a9f78db97c2"), 9, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3abdaeed-d8fe-41e9-97d5-a77a71572f4e"), 10, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("339481f1-ebbd-437c-b74a-a1dcfd835eef"), 11, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b4611e7-b47d-41f0-8faa-620e1552e75f"), 12, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ee2b6a47-4224-4db9-80d9-65de2f9efee7"), 0, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5ec1d5cc-5520-40cb-aae2-329309746c44"), 1, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c0f5a85-e13a-4e04-a222-7a03e758c457"), 2, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ffd5ed3b-4fbb-47e8-9a7c-61c7d5b1e113"), 3, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ccf0ba0-232e-41a9-acb3-0d3a59bf1879"), 4, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c4c1a83b-595d-4bd1-ae69-701a4f202dcf"), 5, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("18e69069-078c-402f-959e-c04f104827ee"), 6, new Guid("2e4f7838-6daa-47b5-947a-df151e6296a3"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9d88d02e-917e-4e38-afa9-f6c2b0005ead"), 0, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("37847dc9-7925-4b63-969c-095eb855c4ec"), 1, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8c830a54-4f64-49ca-bd82-a6f0fea60ee2"), 4, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58ccd522-8a23-4d5a-8912-2ccccaab29f6"), 3, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f6bb130d-5311-4d50-8d7a-034c423a69a6"), 2, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bfe07165-f6b2-4d50-94a4-92befb925f38"), 1, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f0900b6-d6c5-4b06-bf09-35befb9c21c1"), 0, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("331ef8d6-42c7-48e8-8c32-128c3674d4b1"), 10, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4a1b9e97-7b51-4059-97ae-a9d7237bfdc6"), 4, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b846a4c4-e3f5-4aa1-8d15-0fafce211022"), 9, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e6c1ea62-32cd-465d-ac06-adfdb05d5e3c"), 7, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fdbb5fed-e517-4b93-ac56-c87327f373d1"), 6, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0079888e-5d18-463f-a8d9-c04611fc8f92"), 5, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b775cb2-4de8-46ca-b031-77c9756893c2"), 4, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d519b6e6-604a-47e2-8535-422c31ca4830"), 3, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ead0f417-c5d8-47ac-b97e-578199388f95"), 2, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbc8342d-74e3-4747-a5dd-77e7ff979321"), 8, new Guid("489b5f38-d53b-434c-88e9-a4be589d6f62"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f734fabd-3fb3-4972-8bf5-bf7d15c1e45d"), 5, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("01b7fa0d-7a15-4b18-82b9-e7748bdd8649"), 3, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a75687b7-4f50-4a85-9598-bc45ca3b10ad"), 1, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0cd36d67-4470-40c9-a386-589da36b9492"), 2, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c033612e-8222-47cb-a244-9fb05bce2e5c"), 3, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("471f5d5d-a69b-4fbb-bb93-5ec7079cac77"), 4, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b4557043-2ae6-4276-b949-f8a6a51c284d"), 5, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd2e0d8f-978c-4840-8a55-a36dcd0cc046"), 6, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8bedcad8-826e-4970-a4ec-8a0b3b55f6e6"), 0, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd9aa862-8a09-45ee-9e74-fb6ff59bb9de"), 1, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2da8cf3e-2dc0-446e-8e5b-8b3a1c166adf"), 2, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74f029c4-4e2e-43f1-9788-84dfe1d6ecea"), 3, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("782ed4e8-7e76-4b0e-85c3-21e68c9cbb6d"), 4, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("371119cc-4e86-44c2-a3c0-478bd47a9ea1"), 5, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6decf93c-b3d3-4a9a-834f-53f26a27848d"), 6, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c325152f-fa03-40e5-a495-52d2ddda9160"), 7, new Guid("3a34c2be-ded5-4887-aab7-9416e8bfd56e"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a69d4da-fd42-4b8b-a4bd-f2b4e52c40d6"), 0, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7d2e2e4-1f8b-4981-a97f-456633b8bcc5"), 1, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7e1b7fb9-9f46-415a-b482-f661688e7659"), 2, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dc6ef99a-72be-49f6-b592-657717380fbe"), 3, new Guid("82a82eb1-293b-4e22-843a-cc8f99936dea"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("897e584d-86fa-442d-9fa9-3a5cdf7a25c7"), 0, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0022c79-9fd3-4181-b07e-7ef233f9b304"), 3, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0198ed40-e9cc-441c-ad48-6c0022c9c789"), 2, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6c6b7008-9327-49c3-b6ea-fa72302efe1b"), 1, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("422aa4a4-da48-4534-a6f9-5342bc8ed2d9"), 0, new Guid("84693ba4-0ff9-47c2-8c62-4d9428e69a98"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f919abcf-9675-4139-9aba-c56e1cb6b54c"), 7, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("068a02c0-2a76-476e-b7e2-ba8042d05c77"), 2, new Guid("054a1d7b-5a8c-4d7b-9130-86c09f9680c9"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1eb35899-5c57-41c0-a0bf-e118b015e7fc"), 7, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3f3bd248-d49b-4b2e-8561-77665ea8f083"), 5, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf9a18ba-c763-40b7-b918-a05dd4b578fc"), 4, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82b9377f-5a87-4a32-b264-986b61e8d292"), 3, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a878228d-1daf-4f3d-9bda-ece021ea8a52"), 2, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bd495739-7207-455a-a262-7bf341474c6f"), 1, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2746354a-0df5-4f8e-9c15-47a5be653974"), 0, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d65d4440-afe7-44bc-8e0b-d4ec699fcc6f"), 6, new Guid("aa1bcebd-7948-41d0-9e50-5abbd0b3694e"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("66d68f8b-3501-4cee-9630-c28e08b84037"), 1, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d4a491d-d5dd-4bb8-978c-a6338dec0bbe"), 6, new Guid("8725d26f-fe37-4faa-93b5-da976c611d9e"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3074305d-f001-4be2-ad67-90e7dd5669ed"), 1, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d6852186-cba9-4357-ac26-bc7dd0ba1eba"), 5, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5e60d05-298f-432d-a6f3-11f99cdb4bdd"), 6, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b55b85cb-f375-467a-b607-a9657a04f7bd"), 7, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9e59970e-8e97-4abe-81c2-04c0dfde6026"), 8, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("875d90b1-43d7-498c-9741-2339c6fa236c"), 9, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dce5cd77-b2c1-4fc3-9fc8-1b3ab7ff7622"), 10, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("402888a2-8ccd-4144-8c8e-5c270cf3c744"), 11, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da5a6c66-7781-4dba-b13e-1662b77d7ec3"), 12, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a202261-0c4c-4147-ba6e-409226a53fa9"), 0, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0dfbf533-e37f-474f-8ddb-31541e4bb17d"), 1, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("afefa825-d026-49b3-bc3f-8e5c0a08abd2"), 2, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ff36be75-61b2-4688-8a6e-e77864378c02"), 3, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("da446a71-2263-4ce5-af72-e90a4c0bb99c"), 4, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("926ba3b7-4eb0-468e-9ce5-fdf411b5ba53"), 5, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("499995b7-cfd1-4649-812e-3d41f9d86cb2"), 6, new Guid("903fae5b-ea83-4411-92e1-03cbbe30b359"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a5210d13-cdd7-4e37-9e2c-2994f4b8a7fd"), 0, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("608f47dd-b38e-4f86-b1b9-a48e4abc6ce9"), 1, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f0124f80-8f3c-499f-a921-78d0d03e861e"), 4, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78540b88-7bfa-499d-82d9-4d5fdaaebffb"), 3, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b566e55a-cce8-4d99-a68a-6b0ae913f85d"), 2, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("969e83fe-7edd-493c-a1dc-fdd21314dbcd"), 1, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("92325b2b-112a-4318-9e92-4864343c299e"), 0, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1f0b7b8e-a534-4aed-946c-74149256ef8f"), 10, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("338c1cf2-4bb5-44d0-94af-658e3b556422"), 4, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("776fc5e8-a970-4b3e-ae4f-581db167ecf9"), 9, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6a1891c3-4073-45b8-9768-4c213f0b6b70"), 7, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f7dfe1f0-3a9b-45d5-adfd-f5c51680450f"), 6, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a05f6e09-4ce3-4afd-beb0-a6b4e5a8c67c"), 5, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d91d4f58-9ee9-4d19-83b4-c93e69f12d7b"), 4, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a5afbdd-a941-48c8-acdb-53e24868f17b"), 3, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1d5dfc4d-e8c1-4dde-a2b5-273ec1e5de88"), 2, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("38a10ccc-63d4-4d96-a077-bfc8d0e16c21"), 8, new Guid("b37b1651-13a9-4bef-9c76-83c0bdda247b"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eb90cd28-9fb4-464d-ba20-18c3ee744377"), 0, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4814e529-eb2f-4460-a0bd-39d01ecc85be"), 3, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4a136080-2e25-458f-a646-f2846eace1fb"), 1, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("241aa99c-8085-4945-a2da-b37f41c6883f"), 2, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("53c6cacd-f5ba-4c92-a89e-1d7fb63f6cea"), 3, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("84fb19ce-7c41-4d32-a150-505d97241d2b"), 4, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1ad02957-7c32-4b24-a8d5-ba08a37ec2d0"), 5, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cf43eb14-4de6-4d0a-9ece-6b5fce2331f5"), 6, new Guid("84a7da06-6863-4f7f-8731-d6793c93e61e"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f0a711b-4a00-48d3-b6a7-3fc955e0b05a"), 0, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("804bd6d6-3e2b-46e5-a9d1-2637ee367b2a"), 1, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bfed7ea3-8065-4b91-bd95-95a535cccdce"), 2, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("16ffeaf8-b8f4-4a94-b4b2-7735abe3cb79"), 3, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("85143ad1-40f0-41ba-b274-f01a7eaf6c04"), 4, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9e13388e-7811-48d5-b122-9d514782f99b"), 5, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6867424c-9f23-4e59-a017-b3a2fe98e113"), 6, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7ff2e826-b4d4-4fa4-82ea-05c82f62488c"), 7, new Guid("baf0cf75-bbcf-47c4-8f74-ac0bf05f4d4b"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5794e1cf-0278-4eb4-8b70-14e500b55815"), 0, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d1afd325-b50c-4125-a77e-8d54bd470813"), 1, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f3fd97af-7774-4626-bce0-a92799dff4a2"), 2, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4672198e-7f6a-4040-b0b8-2aeae7839835"), 3, new Guid("f730728e-c790-4b1e-9e39-3088dc1fb41f"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a357b8a4-fbb4-4a47-94e2-266477b6f32e"), 0, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dc5d296e-64da-4ab8-83e2-ad422f078b77"), 3, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7a26ff79-98d7-4799-923d-f858fb911578"), 2, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("36c45f64-1d0a-4353-ad55-719f40cf8c0f"), 1, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a42c7519-d2cc-4ba4-b11b-a5c8301d1226"), 0, new Guid("c0786318-d7e4-4965-8788-0126104224a0"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6e402ca-1cc5-4f24-842b-a103aa5f8a19"), 7, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("71e98490-0dae-429e-9a4b-c9d64f1138ce"), 2, new Guid("309ba5db-3bc4-4eff-8a67-e7c9641a6207"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6505d57b-3e91-462d-83ad-598764fd10c5"), 7, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("09dcf93b-464d-45b4-a7c3-a177e1f6f134"), 5, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4db58e89-1394-46a6-8cc5-48251cebea12"), 4, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7a94e399-dd5a-4813-8e2f-25d83089b8f0"), 3, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2b3b2782-9270-4079-882c-c85157554a7c"), 2, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e8656a94-3128-4a79-8c8d-b4a1b9e7ec57"), 1, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("40ad67bb-0575-4471-99e6-52a35ee2e9c5"), 0, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8dc5c2ab-4d34-4ef6-8351-ffdf61d2b992"), 6, new Guid("adb41272-d7e6-42c4-83fe-f00dc6f63c46"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2fed809-b4a8-4a37-8e89-c81e046f0d92"), 0, new Guid("fd743d77-fa0e-44e7-9acf-c2226a345d55"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0346789-a6b6-478a-a48c-7459dd93a6c2"), 6, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("476daad7-0bb3-4005-be72-65dc809f81c9"), 5, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("386ba1c8-63c8-4080-bc67-21521d5def6f"), 4, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24b772d1-bcc1-4bb7-bb69-177dd2040461"), 5, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9a62bab9-9ae7-4948-8a74-83383d0ea6a3"), 6, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("284f6efb-a20d-4a57-8170-e9f0cf2676fd"), 7, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0fdb38ea-2b4f-4beb-b1f4-c2e4016c79ca"), 8, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67bbcb4d-a7c0-4669-947e-59c5413202ab"), 9, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("74e0c60f-7f67-4c91-804d-668cfad6ca82"), 10, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b06cba8f-97bd-4efc-9855-014a6d44e8b6"), 11, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fbd8f29c-9c8e-42a5-989f-14517a3ea8e3"), 12, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c9a30de0-a068-4d19-bc9a-e5e7e9350261"), 0, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("79c0ac3c-607f-4a91-aa82-025f6d1d7450"), 1, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8b336e4a-fc45-4f76-91ad-125f908f7d00"), 2, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("617f0399-06f5-461e-8f8d-86bd6f4eeed2"), 3, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ed00969f-9e1f-4b24-b277-df9dd9c633c3"), 4, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a875ee2-5d26-4f38-a552-f3291678cd05"), 5, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c53d3603-6238-4f12-a766-cb5fb05670e5"), 6, new Guid("0fd1f7b6-f785-4985-8893-177a4f4f8787"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("62cca739-62c4-43e8-b6df-b37cdd70ec02"), 0, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4404a4a5-e27e-4729-922b-8f79f624a053"), 3, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a2a6804-7529-472c-95cc-96989bb34d5d"), 2, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4cf9c531-f972-4ce0-9f09-d5710731ca45"), 1, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fd9bed8-790d-48f0-8473-5d233340ecaf"), 0, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9731257e-ff4b-45f2-a317-0bb30af2e0da"), 10, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("78652e1e-7e9d-4757-a5c3-f14f49cfa622"), 9, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("28ea5845-e73f-4fc0-b761-f36d6c9ffed3"), 3, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c8603ad6-3940-443d-b37c-fe941592ba5f"), 8, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("2c2dfef9-446f-4ef9-99ef-ea1792ae7d68"), 6, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3e5ade45-5fc9-4b09-9d43-ab626b51eeaa"), 5, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ba23d332-0f60-48c9-912c-f53fe11505b1"), 4, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d7ac0e18-c114-496f-a8cc-d557b8dd6fd7"), 3, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b263fc37-2982-4522-ba51-e6420b827309"), 2, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5c498a7f-6c0a-4b0d-8a78-d27062ccf7ae"), 1, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0232637b-5e8c-4c12-a92a-26866c41f9ca"), 7, new Guid("81085eb7-78bb-4cbb-8893-2f44d60bbbcb"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("178c77dc-e783-4b89-afac-7b0835e9d140"), 4, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4107505a-8892-46e8-881c-3ed8d03d3436"), 2, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcafbe1e-270e-4240-bb42-14da8a165d55"), 0, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b"), 1, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f"), 2, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146"), 3, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("791f737b-f570-45fb-94c5-8e22861d9b2b"), 4, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5193c0a-fcda-43ca-9b3a-79302b2d4fe4"), 5, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89ced772-f3a2-4c99-95ba-79b8de067858"), 6, new Guid("4b6a46ec-927c-4faf-a3fc-943efddf377e"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bbe9e6f7-0caa-4d2a-b559-d562bdd7c728"), 0, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c516caf8-d319-4f10-820d-93cce49a1b1f"), 1, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("c1d0a3bb-4095-4ffd-a2b0-fa3d5c1edb52"), 2, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a12a3379-b4ed-4584-a2ce-328c2da9501d"), 3, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("82a4cf88-033b-4d64-9234-131fcc8c0cd7"), 4, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("39871f8b-c6f0-4680-9868-9bf1e0a352ba"), 5, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("643a3dc8-53f5-4fe4-8eff-9657f917b4bc"), 6, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8ec5d9b1-2571-422e-aea6-3d05d5795ed9"), 7, new Guid("0e0a485c-94c8-4a5b-8ddd-68efa93c0873"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1b2d6c98-ce4f-4a52-9fdd-7bf7c44aef44"), 0, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("3e45c5bb-0fd2-4513-aabc-8f5033d88178"), 1, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7fa8007e-498b-40e3-ae41-ed94f6d9f81e"), 2, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e7efb385-4303-428f-a97d-59ec22a79459"), 3, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d951996b-f520-4b1a-9ae7-acaee59cc1b5"), 2, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fcb50de6-5b3c-40e2-b62f-4d976ae66416"), 1, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("8d76712a-33c4-4646-afff-470d93864640"), 0, new Guid("1b0d2782-e2df-4c53-a339-b5a185fc247f"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e568667c-c324-4aa6-b65e-67d1a2ea45d5"), 7, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("91474780-b641-43fb-b342-90dd5f19f282"), 7, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d66baaf3-1264-46e3-b191-d2d5bf986489"), 1, new Guid("8f002305-fc03-4425-bc0a-3faf0f238e63"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("a2d4f135-b084-4585-93c8-9e36fbd3b8c2"), 6, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ec836f7a-bd15-4f22-8c2d-6673297983f4"), 4, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("58dd3f9b-9f74-472f-a8ae-2c1cd1718cce"), 3, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("490ccef1-ad72-4ada-ba30-434c4ecd6196"), 2, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("87e80e3a-7911-4576-b512-45611fd9ad51"), 1, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eeb26208-69f3-43b9-b179-b17e6a03d9d2"), 0, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("892dae4f-bcb0-4140-b70a-d7d9ec78269e"), 3, new Guid("e967eece-0088-4e77-a295-7f4fe7432a8b"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67f501d4-b2d2-41cf-b2b6-e9238d5651c6"), 5, new Guid("2fcd85ad-ae5b-451a-8a3f-ff13f7da5ea0"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1126ba55-b7ee-4b80-b84d-861c6620d4e0"), 5, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("06d53e38-0cd2-45b1-bfd9-aee36e28d62a"), 6, new Guid("b4894ca0-ceb6-414e-8f73-a9b3cbdd58e8"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ab3a7d64-443f-4fb4-9aa9-d33ee8f1b1f0"), 0, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Knee dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7daf9d0a-da1e-4763-bcfd-eb83cdaef700"), 5, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "High pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("081dc89e-c4af-4431-882a-18ffac33e1b5"), 6, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Two inch deficit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0a14b0ad-9fb2-488f-9748-4cb39421364f"), 7, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Half board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fb481a14-4dba-42ea-a0cf-eb43c049d965"), 8, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Two board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cb6dd9f3-8ddc-4682-9935-8696b6f3926a"), 9, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Three board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7c923bd5-f100-48fe-a8a6-116994f622c3"), 10, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Four board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("13072c50-7a79-4b56-82f4-b021e7cec04c"), 11, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Five board" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("59b85371-3bbe-46eb-8305-598eb53b365a"), 12, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Towel - 8 cm " });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("dd7c94d3-8979-4c63-b4a3-8bc729ba01ec"), 0, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ba57a80-a63e-488d-a66a-c48b0587969a"), 1, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Narrow" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f65b8cc0-2854-45b4-a8d4-d1abc91e0cb9"), 2, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Wide" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fd73cca8-8fb3-4606-a96e-aed3015ad159"), 3, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Sumo" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0e822bfc-9337-4ead-af92-029bfa2bdcd3"), 4, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Conventional" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b6c8aab0-471b-4bc9-a1a5-23dffe441989"), 5, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Stiff legged" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("f5a5763c-1e7d-43da-b95c-10cb4a8c0392"), 6, new Guid("f0a58a69-0ac4-4097-a56e-5d52807d2ddd"), "Feet up" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b02e9eaa-eee0-4c32-81b2-21d525c94861"), 0, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("fc3d15ff-a663-44cb-bfb6-9be7625934a7"), 1, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Touch and go" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9994e349-3cba-440d-b951-6fbe9dad9b1a"), 4, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Reverse light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4041011c-840c-440f-a7f7-aca91c68c85c"), 3, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Chains" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("1a7ff548-020f-4e06-9801-f90ab9bba2ea"), 2, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Strong band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b9978a15-a9fc-4b30-ae6e-a3caa6ed50e0"), 1, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("75c26836-3897-4bef-a74a-5a5c1c787aaf"), 0, new Guid("e8a05294-5846-456d-bd63-b26f268d7e9f"), "Light band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("6f0ef29d-7bcf-4717-b5a6-401a18126557"), 10, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 003" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("67b87b0c-7ff6-4537-af9b-9ffb630fb1e2"), 4, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Middle pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("44b3a671-2ce2-4c3f-9d47-d8f03a23eeb2"), 9, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 303" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("97399693-2e64-4714-a907-c13b2c9f9fa4"), 7, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 320" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29faa54d-76d7-453f-a349-d52ee37e8927"), 6, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 600" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("edc03336-5eb2-46b7-8f65-01f68fa7e30e"), 5, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 7 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5f2be98e-fbf9-4f46-b0f8-52b2a14bacd1"), 4, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 5 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("ec54d4c4-08ff-48de-9025-f9c061634e87"), 3, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 3 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("24fa36fd-9e03-4368-be1d-080e9e679a5e"), 2, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Pause - 2 count" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0d7b796d-4b87-4376-b7da-55121331840f"), 8, new Guid("a46a08fa-87bf-4f5c-89f5-6627dc1f42da"), "Tempo - 530" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4c083d3a-4b18-477f-8b74-6eebb0923530"), 3, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Low pin" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("68b020c3-ae0a-45f0-9a84-60e00a216f3b"), 2, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Towel" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("b0d028c3-8317-45b3-8a58-b6a1eea55bf5"), 1, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Box" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7c0dff0f-8d1d-4621-be67-6e07f183594e"), 7, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Machine" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0bd28f2b-bb3a-4d78-b912-51d9b16e6a95"), 6, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Buffalo bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("adf6a5ab-27d2-41f8-9f56-04d6a5e1eab1"), 5, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Trap bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("31270d7b-1c02-424b-bd36-0926c786cf12"), 4, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Neutral-grip bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9af2cc90-3b74-4532-b06c-03a7df9f469c"), 3, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Cambered bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d07d073b-4d77-4ca6-b58f-ca585aa1062f"), 2, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Saftey bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("89a0ebc5-8e71-4ea4-a3f9-4822f7811c76"), 0, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("00216c4d-b74c-4a1f-922c-7ee6afade152"), 1, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Dumbbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d74bc6c6-7bb1-42c3-a21a-5ef59ac3dc57"), 6, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Other" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5490db04-9a45-4df4-8da3-ee7a98c2fd8f"), 5, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Vertical pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("869eb287-d280-4496-a2b0-034c79740de1"), 4, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Vertical push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("cea4c943-7004-4152-9d38-c5abbeb6708d"), 3, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Horizontal pull" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7b67b26e-53d3-4741-a3a8-4875b84b26b6"), 2, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Horizontal push" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("7da52905-91ab-4ea2-8bb6-73b6601b8d02"), 1, new Guid("6a7913ed-4e88-48d3-b56a-81fbe6c22ae6"), "Hip dominant" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("916b0fa6-658a-43c7-8fdf-6c5634bd68f0"), 0, new Guid("d7aaee32-5149-4f0a-a489-c6ad899d8c06"), "Barbell" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("29450890-4e8e-4702-9e62-99db094dc7d4"), 5, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse average band" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5e2e8537-d4e3-4be9-b363-fb15adcbe149"), 1, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "High bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("4fb30e6f-01b1-4a09-947b-ba02992d1186"), 3, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Front rack" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("aa39a679-bf39-45c1-be60-422b302e5995"), 0, new Guid("d0435460-e5b0-45f7-81e0-f1c38da9bdca"), "Standard" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("945733a8-c533-46b5-b148-81f67ad683cb"), 3, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Wide grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("209296ec-d07a-4600-9ff1-fd9b015220f7"), 2, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Close grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("17db6a19-3549-4e36-8334-38c390fb93a6"), 1, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Reverse grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("eaea3a53-0196-45e7-87b5-0d4224d8e036"), 0, new Guid("e19dc359-ea7f-4af6-86ce-6d1523344270"), "Snatch grip" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("5626439e-8f52-45f5-8ab1-651568732ad9"), 7, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Wrist wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("0c8ea577-fec7-459f-8d7a-cc61304fab9e"), 2, new Guid("d52e9116-8c31-4478-9892-641cdfbd51b9"), "Low bar" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d3e386fd-2536-4a53-82c5-26cc8daac3d8"), 7, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Deadlift suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("abb06c4f-3123-4f05-a5ab-83b7fd88a199"), 5, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Squat suit" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("bd46bbf2-e847-413a-9eb2-3f4d6d5f3469"), 4, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Breifs" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("86304bf9-ad46-49c1-b172-f1f983c6cdd8"), 3, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Slingshot" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("9ddbc8bd-abcc-41fb-844c-db019ff97bbb"), 2, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Knee wraps" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("90fbcf3d-9628-41dc-8850-9dceb4bd3956"), 1, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Knee sleeves" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("d5117871-e694-4e39-9f33-73f69339eded"), 0, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Belt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("e4f15bd2-95dc-41a8-8a48-196ea2a633bf"), 6, new Guid("2325725d-4094-4cb8-b7c6-f8b03fd4c9c3"), "Bench shirt" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Order", "TagGroupId", "Value" },
                values: new object[] { new Guid("235cee46-fd12-4a04-813d-87e6d8bd4212"), 6, new Guid("bbfdc279-f02a-4526-881e-89b2c66a8263"), "Reverse strong band" });

            migrationBuilder.InsertData(
                table: "ExerciseTypeTags",
                columns: new[] { "Id", "ExerciseTypeId", "Show", "TagId" },
                values: new object[,]
                {
                    { new Guid("d64a3082-1867-4221-9a2c-5ce7c83966a3"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("2b1460b4-edf4-46ac-91ef-aed394506be3"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("c91db4e5-2909-4599-a263-c31274e69547"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("c3424e20-04f0-4137-ab14-e03f8a1d3627"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f") },
                    { new Guid("9efb40f2-dec4-41b7-9456-c329e254996f"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("d8bf2223-2ba3-4324-b3bd-c83c1bf7511f") },
                    { new Guid("0b37dc97-9ffc-4a7e-9269-339b5bd3651f"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b") },
                    { new Guid("bec2e87b-34c1-475a-a81a-d74a622e079b"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("a7165c19-c954-4685-b7e1-8442ae8c335b") },
                    { new Guid("5e2e88e3-d845-4b30-bded-f382c2ec3ff7"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("b2a30e8b-95dc-4416-be4e-80100a990d2e"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("d9084bce-d342-4e37-8777-ecfb74bdc56d"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("7a5dbced-c757-47ba-86b7-91b937733873"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("16797f2d-9afb-42f9-9b30-69084e80577e"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("76899505-0a20-4581-88c7-a066a334566d"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("51625d5b-63e1-4fe9-b3ba-f57067c751ae"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("905f8b68-3adc-4840-ab3d-c9bfdf0cf7f2"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("46479c5b-616e-4d0a-852c-ca5358f9f40c"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), false, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("d80ab46e-c738-49d0-8116-08da0b9340c7"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("c0a67e7b-14ce-469d-b760-aae663a12f11"), new Guid("293539ff-7afb-47df-b0fa-fa50f8210e9b"), true, new Guid("3251f3ad-f47a-4589-9b19-ca4e6a3153ab") },
                    { new Guid("b0cb9792-b914-4c3f-96fd-eb1c48ce2763"), new Guid("56f59bf6-3cfd-4c15-bef0-a16809205483"), false, new Guid("11e3795e-c511-408e-a3a6-1c5abd4f6146") },
                    { new Guid("228a4692-b06a-4ac2-8608-5448a05cba72"), new Guid("059c418b-93d1-45af-ae95-cb3cb35a32ad"), true, new Guid("c516caf8-d319-4f10-820d-93cce49a1b1f") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeTags_ExerciseTypes_ExerciseTypeId",
                table: "ExerciseTypeTags",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseTypeTags_Tags_TagId",
                table: "ExerciseTypeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}