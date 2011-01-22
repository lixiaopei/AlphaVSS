/* Copyright (c) 2008-2011 Peter Palotas
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *  copies of the Software, and to permit persons to whom the Software is
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 *  THE SOFTWARE.
 */
using System;
using System.Collections.Generic;

namespace Alphaleonis.Win32.Vss
{
   /// <summary>
   /// The <see cref="IVssDifferentialSoftwareSnapshotManagement"/> interface contains methods that allow applications to query and 
   /// manage shadow copy storage areas generated by the system shadow copy provider.
   /// </summary>
   /// <remarks>
   ///     <para>
   ///         <note>
   ///             <para>
   ///                 <b>Windows XP: </b> This interface requires Windows Server 2003 or later.
   ///             </para>
   ///         </note>
   ///     </para>
   /// </remarks>
   public interface IVssDifferentialSoftwareSnapshotManagement
   {
      //
      // From IVssDifferentialSoftwareSnapshotMgmt
      //
      /// <summary>
      /// The <see cref="AddDiffArea"/> method adds a shadow copy storage area association for the specified volume. 
      /// If the association is not supported, an exception will be thrown.
      /// </summary>
      /// <param name="volumeName">
      /// <para>
      ///     Name of the volume that will be the source of shadow copies that is to be associated 
      ///     with a shadow copy storage area on the <paramref name="volumeName"/> volume.
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <param name="diffAreaVolumeName">
      /// <para>
      ///     Name of the volume that 
      ///     will contain the shadow copy storage area to be associated with the 
      ///     <paramref name="volumeName"/> volume. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      ///  </param>
      /// <param name="maximumDiffSpace">
      /// <para>
      ///     Specifies the maximum size, in bytes, of the shadow copy storage area on the volume. 
      ///     This value must be at least 300 MB, up to the system-wide limit.
      /// </para>
      /// <para>
      ///     Windows Server 2003:  Prior to 
      ///     Windows Server 2003 SP1 the shadow copy storage area size was fixed at 100 MB.
      /// </para>
      /// </param>
      /// <remarks>
      ///     <para>
      ///         <note>
      ///             <para>
      ///                 <b>Windows XP:</b> This method is not supported until Windows Server 2003.
      ///             </para>
      ///         </note>
      ///     </para>
      /// </remarks>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssObjectAlreadyExistsException">The association between the <paramref name="volumeName"/> and <paramref name="diffAreaVolumeName"/> volumes already exists.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssVolumeNotSupportedException">The <paramref name="diffAreaVolumeName"/> volume is not NTFS or has insufficient free space.</exception>
      /// <exception cref="VssMaximumDiffAreaAssociationsReachedException">The maximum number of shadow copy storage areas has been added to the shadow copy source volume. The specified shadow copy storage volume was not associated with the specified shadow copy source volume.</exception>
      void AddDiffArea(string volumeName, string diffAreaVolumeName, Int64 maximumDiffSpace);

      /// <summary>
      /// The <see cref="O:Alphaleonis.Win32.Vss.IVssDifferentialSoftwareSnapshotManagement.ChangeDiffAreaMaximumSize"/> method updates the shadow copy storage area maximum size 
      /// for a certain volume. This may not have an immediate effect.
      /// </summary>
      /// <overloads>
      /// Updates the shadow copy storage area maximum size 
      /// for a certain volume. This method has two overloads.
      /// </overloads>
      /// <param name="volumeName">
      /// <para>
      ///     Name of the volume that is the source of shadow copies that are associated with a shadow copy 
      ///     storage area on the <paramref name="diffAreaVolumeName"/> volume. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <param name="diffAreaVolumeName">
      /// <para>
      ///     Name of the volume that contains the shadow copy storage area associated with 
      ///     the <paramref name="volumeName"/> volume. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <param name="maximumDiffSpace">
      ///     Specifies the maximum size, in bytes, for the shadow copy storage area to 
      ///     use for the volume. If this value is zero, the shadow copy storage area will be disabled.
      /// </param>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssObjectNotFoundException">The association between the <paramref name="volumeName"/> and <paramref name="diffAreaVolumeName"/> volumes was not found.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssInsufficientStorageException">The <paramref name="diffAreaVolumeName"/> volume does not have sufficient free space.</exception>
      /// <exception cref="VssVolumeInUseException">A shadow copy is currently using the shadow copy storage area.</exception>
      void ChangeDiffAreaMaximumSize(string volumeName, string diffAreaVolumeName, Int64 maximumDiffSpace);

      /// <summary>
      /// The <see cref="QueryDiffAreasForSnapshot"/> method queries shadow copy storage areas in use by the 
      /// original volume associated with the input shadow copy.
      /// </summary>
      /// <param name="snapshotId">The snapshot id.</param>
      /// <returns>A list of <see cref="VssDiffAreaProperties"/> describing the shadow copy storage areas in use by the 
      /// shadow copy specified.</returns>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>        
      IList<VssDiffAreaProperties> QueryDiffAreasForSnapshot(Guid snapshotId);

      /// <summary>
      /// The <see cref="QueryDiffAreasForVolume"/> method queries shadow copy storage areas in use by the volume specified.
      /// </summary>
      /// <param name="volumeName">
      /// <para>
      ///     Name of the volume that contains shadow copy storage areas. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <returns>A list containing <see cref="VssDiffAreaProperties"/> objects describing the shadow 
      /// copy storage areas in use by the volume specified.</returns>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>        
      IList<VssDiffAreaProperties> QueryDiffAreasForVolume(string volumeName);

      /// <summary>
      /// The <see cref="QueryDiffAreasOnVolume"/> method queries shadow copy storage areas that physically 
      /// reside on the given volume
      /// </summary>
      /// <param name="volumeName">
      /// <para>
      ///     Name of the volume that contains shadow copy storage areas. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <returns>A list of <see cref="VssDiffAreaProperties"/> objects describing the 
      /// shadow copy storage areas that physically reside on the given volume.</returns>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>        
      IList<VssDiffAreaProperties> QueryDiffAreasOnVolume(string volumeName);

      /// <summary>
      /// The <see cref="QueryVolumesSupportedForDiffAreas"/> method queries volumes that support shadow copy storage 
      /// areas (including volumes with disabled shadow copy storage areas).
      /// </summary>
      /// <param name="originalVolumeName">
      /// <para>
      ///     Name of the original volume that is the source of the shadow copies.  
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <returns>A list of <see cref="VssDiffVolumeProperties"/> describing the volumes that support shadow 
      /// copy storage areas (including volumes with disabled shadow copy storage areas).</returns>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>        
      IList<VssDiffVolumeProperties> QueryVolumesSupportedForDiffAreas(string originalVolumeName);

      //
      // From IVssDifferentialSoftwareSnapshotMgmt2
      //
      /// <summary>
      /// The <see cref="O:Alphaleonis.Win32.Vss.IVssDifferentialSoftwareSnapshotManagement.ChangeDiffAreaMaximumSize"/> method updates the shadow copy storage area maximum size 
      /// for a certain volume. This may not have an immediate effect.
      /// </summary>
      /// <param name="volumeName">
      /// <para>
      ///     Name of the volume that is the source of shadow copies that are associated with a shadow copy 
      ///     storage area on the <paramref name="diffAreaVolumeName"/> volume. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <param name="diffAreaVolumeName">
      /// <para>
      ///     Name of the volume that contains the shadow copy storage area associated with 
      ///     the <paramref name="volumeName"/> volume. 
      /// </para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      /// </param>
      /// <param name="maximumDiffSpace">
      ///     Specifies the maximum size, in bytes, for the shadow copy storage area to 
      ///     use for the volume. If this value is zero, the shadow copy storage area will be disabled.
      /// </param>
      /// <param name="isVolatile">
      ///     <para>
      ///         <see langword="true"/> to indicate that the effect of calling the 
      ///         <see cref="O:Alphaleonis.Win32.Vss.IVssDifferentialSoftwareSnapshotManagement.ChangeDiffAreaMaximumSize"/> method should not continue if 
      ///         the computer is rebooted; otherwise, <see langword="false"/>.
      ///     </para>
      ///     <para>
      ///         If the <paramref name="maximumDiffSpace"/> parameter is zero, the 
      ///         <paramref name="isVolatile"/> parameter must be <see langword="false"/>.
      ///     </para>
      /// </param>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="SystemException">Unexpected error. The error code is logged in the error log file.</exception>
      /// <exception cref="VssObjectNotFoundException">The association between the <paramref name="volumeName"/> and <paramref name="diffAreaVolumeName"/> volumes was not found.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssInsufficientStorageException">The <paramref name="diffAreaVolumeName"/> volume does not have sufficient free space.</exception>
      /// <exception cref="VssVolumeInUseException">A shadow copy is currently using the shadow copy storage area.</exception>
      void ChangeDiffAreaMaximumSize(string volumeName, string diffAreaVolumeName, Int64 maximumDiffSpace, bool isVolatile);

      //
      // From IVssDifferentialSoftwareSnapshotMgmt3
      //
      /// <summary>
      /// Clears the protection fault state for the specified volume.
      /// </summary>
      /// <para>
      ///     Name of the volume that will be the source of shadow copies that is to be associated 
      ///     with a shadow copy storage area on the <paramref name="volumeName"/> volume.
      /// </para>
      /// <param name="volumeName">
      /// <para>The name of the volume. This parameter is required and cannot be <see langword="null"/>.</para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      ///  </param>
      ///  <remarks>
      ///  <para>
      ///     The <see cref="ClearVolumeProtectFault"/> method dismounts the volume and resets the 
      ///     volume's protection fault member to <see langword="false"/> to allow normal I/O to continue 
      ///     on the volume. If the volume is not in a faulted state, this method does nothing.
      ///  </para>
      ///  <para>
      ///     <note>
      ///         <para>
      ///             <b>Windows XP, Windows Server 2003 and Windows Vista:</b> This method requires Windows Server 2008.
      ///         </para>
      ///     </note>
      ///  </para>
      ///  </remarks>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="NotImplementedException">The provider for the volume does not support shadow copy protection.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssObjectNotFoundException">The specified volume was not found.</exception>
      void ClearVolumeProtectFault(string volumeName);


      /// <summary>
      /// Deletes all shadow copy storage areas (also called diff areas) on the specified volume that are not in use.
      /// </summary>
      /// <param name="diffAreaVolumeName">
      /// <para>The name of the volume. This parameter is required and cannot be <see langword="null"/>.</para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      ///  </param>
      ///  <remarks>
      ///  <para>
      ///  Unused shadow copy storage area files are found on storage area volumes when the associated original 
      ///  volume is offline due to a protection fault. In certain cases, the original volume may be 
      ///  permanently lost, and calling the <see cref="DeleteUnusedDiffAreas"/> method is the only way to 
      ///  recover the abandoned storage area space.
      ///  </para>
      ///  <para>
      ///     <note>
      ///         <para>
      ///             <b>Windows XP, Windows Server 2003 and Windows Vista:</b> This method requires Windows Server 2008.
      ///         </para>
      ///     </note>
      ///  </para>
      ///  </remarks>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="NotImplementedException">The provider for the volume does not support shadow copy protection.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssObjectNotFoundException">The specified volume was not found.</exception>
      void DeleteUnusedDiffAreas(string diffAreaVolumeName);

      /// <summary>
      /// Gets the shadow copy protection level and status for the specified volume.
      /// </summary>
      /// <param name="volumeName">
      /// <para>The name of the volume. This parameter is required and cannot be <see langword="null"/>.</para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      ///  </param>
      /// <returns>A <see cref="VssVolumeProtectionInfo"/> class instance that contains information about the volume's 
      /// shadow copy protection level.</returns>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="NotImplementedException">The provider for the volume does not support shadow copy protection.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssObjectNotFoundException">The specified volume was not found.</exception>
      ///  <para>
      ///     <note>
      ///         <para>
      ///             <b>Windows XP, Windows Server 2003 and Windows Vista:</b> This method requires Windows Server 2008.
      ///         </para>
      ///     </note>
      ///  </para>
      /// <remarks>
      /// <para>
      /// The <see cref="GetVolumeProtectionLevel"/> method gets information about the volume's current protection level. 
      /// If the volume is in a faulted state, the <see cref="VssVolumeProtectionInfo.ProtectionFault"/> member of the 
      /// <see cref="VssVolumeProtectionInfo"/> structure contains the current protection fault, 
      /// and the <see cref="VssVolumeProtectionInfo.FailureStatus"/> member contains the reason why the volume 
      /// is in a faulted state. If the volume is not in a faulted state, 
      /// the <see cref="VssVolumeProtectionInfo.ProtectionFault"/> and <see cref="VssVolumeProtectionInfo.FailureStatus"/>
      /// members will be zero.
      /// </para>
      /// </remarks>
      VssVolumeProtectionInfo GetVolumeProtectionLevel(string volumeName);


      /// <summary>
      /// Sets the shadow copy protection level for an original volume or a shadow copy storage area volume.
      /// </summary>
      /// <param name="volumeName">
      /// <para>The name of the volume. This parameter is required and cannot be <see langword="null"/>.</para>
      /// <para>
      ///     The name of the volume must be in one of the following formats:
      ///     <list type="bullet">
      ///         <item>
      ///             <description>
      ///                 The path of a volume mount point with a backslash (\)
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A drive letter with backslash (\), for example, <c>D:\</c>
      ///             </description>
      ///          </item>
      ///         <item>
      ///             <description>
      ///                 A unique volume name of the form <c>\\?\Volume{GUID}\</c> (where 
      ///                 GUID is the unique global identifier of the volume) with a backslash (\)
      ///             </description>
      ///          </item>
      ///      </list>
      ///  </para>
      ///  </param>
      /// <param name="protectionLevel">
      ///     A value from the <see cref="VssProtectionLevel"/> enumeration that specifies the shadow 
      ///     copy protection level.
      /// </param>
      /// <exception cref="UnauthorizedAccessException">Caller does not have sufficient backup privileges or is not an administrator.</exception>
      /// <exception cref="OutOfMemoryException">The caller is out of memory or other system resources.</exception>
      /// <exception cref="ArgumentException">One of the parameter values is not valid.</exception>
      /// <exception cref="ArgumentNullException">One of the arguments was <see langword="null"/></exception>
      /// <exception cref="NotImplementedException">The provider for the volume does not support shadow copy protection.</exception>
      /// <exception cref="VssProviderVetoException">Expected provider error. The provider logged the error in the event log.</exception>
      /// <exception cref="VssObjectNotFoundException">The specified volume was not found.</exception>
      /// <remarks>
      ///     <para>
      ///         The <see cref="SetVolumeProtectionLevel"/> method checks the current shadow copy protection 
      ///         level of the volume. If the volume is in a faulted state and 
      ///         <see cref="VssProtectionLevel.OriginalVolume"/> is specified for the 
      ///         <paramref name="protectionLevel"/> parameter, <see cref="SetVolumeProtectionLevel"/> dismounts 
      ///         the volume before setting the protection level.
      ///     </para>
      ///     <para>
      ///         If the current protection level of the volume is the same as the value of the 
      ///         <paramref name="protectionLevel"/> parameter, 
      ///         <see cref="SetVolumeProtectionLevel"/> does nothing.
      ///     </para>
      ///  <para>
      ///     <note>
      ///         <para>
      ///             <b>Windows XP, Windows Server 2003 and Windows Vista:</b> This method requires Windows Server 2008.
      ///         </para>
      ///     </note>
      ///  </para>
      /// </remarks>
      void SetVolumeProtectionLevel(string volumeName, VssProtectionLevel protectionLevel);
   }
}
